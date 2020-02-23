using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HdcDst.Utils
{
    public interface IStateEngineState
    {
        void SetStateEngine(IStateEngine stateEngine);

        Task OnEvent<T>(T ev);

        Task OnEnter(IEnterParameters parameters);
    }
}
