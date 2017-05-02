using Castle.Windsor;
using Castle.Windsor.Installer;
using FlightScheduling.Core.DomainModel;
using FlightSchedulingProject.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FlightScheduling.Tests.Tests
{
    [TestClass]
    public class FlightControllerTests
    {
        FlightController flightDataController;

        [TestInitialize]
        public void SetupTest()
        {
            using (IWindsorContainer _container = new WindsorContainer())
            {
                _container.Install(FromAssembly.This());

                flightDataController = _container.Resolve<FlightController>();
            }
        }

        [TestMethod]
        public void FlightController_GetAllFlightsTest()
        {
            IEnumerable<FlightModel> flightResponse = flightDataController.GetAllFlights();
            Assert.IsNotNull(flightResponse);
            Assert.AreEqual(20, ((List<FlightModel>)flightResponse).Count);
        }
    }
}
