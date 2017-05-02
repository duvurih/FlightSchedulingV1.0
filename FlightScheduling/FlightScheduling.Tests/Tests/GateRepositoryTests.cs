using Castle.Windsor;
using Castle.Windsor.Installer;
using FlightScheduling.Core.DomainModel;
using FlightScheduling.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FlightScheduling.Tests.Tests
{
    [TestClass]
    public class GateRepositoryTests
    {
        private iGateInterface gateDataRepository;

        [TestInitialize]
        public void SetupTest()
        {
            //TestInitializationSettings.HttpInitialization();

            using (IWindsorContainer _container = new WindsorContainer())
            {
                _container.Install(FromAssembly.This());

                gateDataRepository = _container.Resolve<iGateInterface>();
            }

        }

        [TestMethod]
        public void GateRepository_GetAllGatesTest()
        {
            List<GateModel> gateResponse = gateDataRepository.GetAllGates();
            Assert.IsNotNull(gateResponse);
            Assert.AreEqual(2, gateResponse.Count);
        }
    }
}
