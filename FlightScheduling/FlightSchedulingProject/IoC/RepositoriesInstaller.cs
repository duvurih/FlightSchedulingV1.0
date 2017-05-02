using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FlightScheduling.Core.Interfaces;
using FlightScheduling.Infrastructure.Repositories;

namespace FlightSchedulingProject.IoC
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<iGateInterface>().ImplementedBy<GateRepository>().LifestylePerWebRequest()
                );

            container.Register(
                Component.For<iFlightInterface>().ImplementedBy<FlightsRepository>().LifestylePerWebRequest()
                );
        }
    }
}
