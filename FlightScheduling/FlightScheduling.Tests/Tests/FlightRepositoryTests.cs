using Castle.Windsor;
using Castle.Windsor.Installer;
using FlightScheduling.Core.DomainModel;
using FlightScheduling.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace FlightScheduling.Tests.Tests
{
    [TestClass]
    public class FlightRepositoryTests
    {
        private iFlightInterface flightDataRepository;

        [TestInitialize]
        public void SetupTest()
        {
            //TestInitializationSettings.HttpInitialization();

            using (IWindsorContainer _container = new WindsorContainer())
            {
                _container.Install(FromAssembly.This());

                flightDataRepository = _container.Resolve<iFlightInterface>();
            }
        }

        [TestMethod]
        public void FlightRepository_GetAllFlightsTest()
        {
            IEnumerable<FlightModel> flightResponse = flightDataRepository.GetAllFlights();
            Assert.IsNotNull(flightResponse);
            Assert.AreEqual(20, ((List<FlightModel>)flightResponse).Count);
        }

        [TestMethod]
        public void FlightRepository_AddFlightGate1Test()
        {
            var gateId = 1;
            var i = 11;
            FlightModel flightModelData = new FlightModel()
            {
                FlightID = (gateId * 100) + i,
                FlightName = "Flight " + ((gateId * 100) + i),
                GateID = gateId,
                DepartureTime = DateTime.Now.AddMinutes((30 * i) + 29),
                ArrivalTime = DateTime.Now.AddMinutes((30 * i)),
                CancellationStatus = (i == 10) ? true : false,
                Rescheduled = false
            };
            bool result = flightDataRepository.AddFlight(flightModelData);
            Assert.IsNotNull(result);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void FlightRepository_AddFlightGate2Test()
        {
            var gateId = 2;
            var i = 11;
            FlightModel flightModelData = new FlightModel()
            {
                FlightID = (gateId * 100) + i,
                FlightName = "Flight " + ((gateId * 100) + i),
                GateID = gateId,
                DepartureTime = DateTime.Now.AddMinutes((30 * i) + 29),
                ArrivalTime = DateTime.Now.AddMinutes((30 * i)),
                CancellationStatus = (i == 10) ? true : false,
                Rescheduled = false
            };
            bool result = flightDataRepository.AddFlight(flightModelData);
            Assert.IsNotNull(result);
            Assert.AreEqual(true, result);
        }
    }
}
