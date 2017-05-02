using FlightScheduling.Core.DomainModel;
using System.Collections.Generic;

namespace FlightScheduling.Infrastructure.DataInitialization
{
    public static class GatesDataInitialization
    {
        public static List<GateModel> GatesData()
        {
            List<GateModel> gateModelData = new List<GateModel>();

            gateModelData.Add(new GateModel { GateID = 1, GateName = "Gate A", GateLocation = "North Wing", FlightCounter = 110 });
            gateModelData.Add(new GateModel { GateID = 2, GateName = "Gate B", GateLocation = "South Wing", FlightCounter = 210 });
            return gateModelData;
        }
    }
}
