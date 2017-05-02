using FlightScheduling.Core.DomainModel;
using System.Collections.Generic;

namespace FlightScheduling.Core.Interfaces
{
    public interface iGateInterface
    {
        #region "Get Methods"
        List<GateModel> GetAllGates();
        #endregion

        #region "Add Methods"
        bool AddGate(GateModel gate);
        #endregion
    }
}
