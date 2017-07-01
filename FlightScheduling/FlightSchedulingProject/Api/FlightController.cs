using FlightScheduling.Core.DomainModel;
using FlightScheduling.Core.Interfaces;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FlightSchedulingProject.Api
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/FlightService")]
    public class FlightController : ApiController
    {
        #region "Members"
        iFlightInterface _flightRepository;
        #endregion

        #region "Constructor"
        /// <summary>
        /// Constructor creating a flight repository
        /// </summary>
        /// <param name="flightRepository"></param>
        public FlightController(iFlightInterface flightRepository)
        {
            _flightRepository = flightRepository;
        }
        #endregion

        #region "Get Methods"
        /// <summary>
        /// Retrieving all flights
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllFlights")]
        public IEnumerable<FlightModel> GetAllFlights()
        {
            return _flightRepository.GetAllFlights();
        }
        #endregion

        #region "Add Methods"
        /// <summary>
        /// Adding new flight
        /// </summary>
        /// <param name="flight"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddFlight")]
        public bool AddFlight(FlightModel flight)
        {
            return _flightRepository.AddFlight(flight);
        }
        #endregion
    }
}