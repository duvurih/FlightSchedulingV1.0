using FlightScheduling.Core.DomainModel;
using FlightScheduling.Core.Interfaces;
using FlightScheduling.Infrastructure.DataInitialization;
using System.Collections.Generic;

namespace FlightScheduling.Infrastructure.Repositories
{
    public class GateRepository : iGateInterface
    {
        #region "Get Methods"
        public List<GateModel> GetAllGates()
        {
            return GatesDataInitialization.GatesData();
        }
        #endregion

        #region "Add Methods"
        public bool AddGate(GateModel gate)
        {
            List<GateModel> gateData = GatesDataInitialization.GatesData();
            gateData.Add(gate);
            return true;
        }
        #endregion

    }
}
