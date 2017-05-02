using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FlightScheduling.Core.Interfaces;
using FlightScheduling.Infrastructure.Repositories;
using FlightSchedulingProject.Api;
using System.Web.Http;

namespace FlightScheduling.Tests.IOC
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .BasedOn<ApiController>());

            container.Register(
                Component.For<iGateInterface>().ImplementedBy<GateRepository>()
                );

            container.Register(
                Component.For<iFlightInterface>().ImplementedBy<FlightsRepository>()
                );

            container.Register(
                Component.For<FlightController>().ImplementedBy<FlightController>()
                );

            container.Register(
                Component.For<GateController>().ImplementedBy<GateController>()
                );
        }
    }
}
