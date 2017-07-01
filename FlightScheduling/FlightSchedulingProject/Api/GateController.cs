using FlightScheduling.Core.DomainModel;
using FlightScheduling.Core.Interfaces;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FlightSchedulingProject.Api
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/GateService")]
    public class GateController : ApiController
    {
        #region "Members"
        iGateInterface _gateRepository;
        #endregion

        #region "Constructor"
        /// <summary>
        /// Constructor creating the instance of gate repository
        /// </summary>
        /// <param name="gateRepository"></param>
        public GateController(iGateInterface gateRepository)
        {
            _gateRepository = gateRepository;
        }
        #endregion

        #region "Get Methods"
        /// <summary>
        /// Retrieve All Gates
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllGates")]
        public List<GateModel> GetAllGates()
        {
            return _gateRepository.GetAllGates();
        }
        #endregion

        #region "Add Methods"
        /// <summary>
        /// Adding a new gate
        /// </summary>
        /// <param name="gate"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddGate")]
        public bool AddGate(GateModel gate)
        {
            return _gateRepository.AddGate(gate);
        }
        #endregion
    }
}