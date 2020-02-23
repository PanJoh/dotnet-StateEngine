using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HdcDst.Utils
{
    public interface IStateEngine
    {
        void SetNextState(string stateId, IEnterParameters enterParams = null);

        Task Start(string initialState, IEnterParameters parameters = null);

        void AddState(string stateId, IStateEngineState state);
        
        Task OnEvent<T>(T ev);
    }
}
