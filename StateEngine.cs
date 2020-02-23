using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HdcDst.Utils
{
    public class StateEngine : IStateEngine
    {
        private IStateEngineState currentState;
        private IStateEngineState nextState;
        private IEnterParameters enterParameters;

        private readonly IDictionary<string, IStateEngineState> stateIdMap;

        public StateEngine()
        {
            stateIdMap = new Dictionary<string, IStateEngineState>();
        }

        public void SetNextState(string stateId, IEnterParameters enterParameters = null)
        {
            if(!stateIdMap.TryGetValue(stateId, out nextState))
            {
                return;
            }

            this.enterParameters = enterParameters;
        }

        public void AddState(string stateId, IStateEngineState state)
        {
            stateIdMap.Add(stateId, state);
            state.SetStateEngine(this);
        }

        public async Task Start(string initialState, IEnterParameters parameters = null)
        {
            currentState = null;
            stateIdMap.TryGetValue(initialState, out currentState);
            if(currentState == null)
            {
                throw new NotSupportedException($"Ther is no state for state id '{initialState}'");
            }

            await currentState.OnEnter(enterParameters);
            await NextStateHandeling();
        }

        public async Task OnEvent<T>(T ev)
        {
            if (currentState == null)
            {
                throw new NotSupportedException("No current state");
            }

            try
            {
                await currentState.OnEvent(ev);

            } catch(NotSupportedException ex)
            {
                throw new NotSupportedException($"Event {typeof(T)} is not supported in the current state", ex);
            }

            await NextStateHandeling();
        }

        private async Task NextStateHandeling()
        {
            while(nextState != null)
            {
                currentState = nextState;
                nextState = null;
                await currentState.OnEnter(enterParameters);
            }
        }
    }
}
