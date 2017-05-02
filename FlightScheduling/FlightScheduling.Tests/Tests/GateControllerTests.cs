using Castle.Windsor;
using Castle.Windsor.Installer;
using FlightScheduling.Core.DomainModel;
using FlightSchedulingProject.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FlightScheduling.Tests.Tests
{
    [TestClass]
    public class GateControllerTests
    {
        GateController gateDataController;

        [TestInitialize]
        public void SetupTest()
        {
            using (IWindsorContainer _container = new WindsorContainer())
            {
                _container.Install(FromAssembly.This());

                gateDataController = _container.Resolve<GateController>();
            }
        }

        [TestMethod]
        public void GateController_GetAllGatesTest()
        {
            List<GateModel> gateResponse = gateDataController.GetAllGates();
            Assert.IsNotNull(gateResponse);
            Assert.AreEqual(2, gateResponse.Count);
        }
    }
}
