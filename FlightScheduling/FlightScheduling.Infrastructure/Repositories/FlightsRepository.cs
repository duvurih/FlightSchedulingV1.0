using FlightScheduling.Core.DomainModel;
using FlightScheduling.Core.Interfaces;
using FlightScheduling.Infrastructure.DataInitialization;
using System.Collections.Generic;
using System.Linq;

namespace FlightScheduling.Infrastructure.Repositories
{
    public class FlightsRepository : iFlightInterface
    {

        #region "Get Methods"
        public IEnumerable<FlightModel> GetAllFlights()
        {
            List<GateModel> gateModelData = GatesDataInitialization.GatesData();

            List<FlightModel> flightData = FlightDataInitialization.FlightData(gateModelData.First().GateID);
            flightData.AddRange(FlightDataInitialization.FlightData(gateModelData.Last().GateID));
            return flightData.AsEnumerable<FlightModel>();
        }
        #endregion

        #region "Add Methods"
        public bool AddFlight(FlightModel flight)
        {
            List<FlightModel> flightData = FlightDataInitialization.FlightData(flight.GateID);
            flightData.Add(flight);
            return true;
        }
        #endregion

    }
}
