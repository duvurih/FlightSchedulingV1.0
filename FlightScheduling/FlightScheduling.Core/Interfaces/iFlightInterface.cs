using FlightScheduling.Core.DomainModel;
using System.Collections.Generic;

namespace FlightScheduling.Core.Interfaces
{
    public interface iFlightInterface
    {
        #region "Get Methods"
        IEnumerable<FlightModel> GetAllFlights();
        #endregion

        #region "Add Methods"
        bool AddFlight(FlightModel flight);
        #endregion
    }
}
