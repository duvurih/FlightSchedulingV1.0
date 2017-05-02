using Castle.Windsor;
using Castle.Windsor.Installer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Web.Http;

namespace FlightScheduling.Tests.Tests
{
    [TestClass]
    public class FlightApiTests
    {
        HttpServer _server;
        HttpClient _client;
        HttpConfiguration _config;

        [TestInitialize]
        public void SetupTest()
        {
            _config = new HttpConfiguration();
            _config.Routes.MapHttpRoute("default",
                "api/{controller}/{id}", new { id = RouteParameter.Optional });

            using (IWindsorContainer _container = new WindsorContainer())
            {
                _container.Install(FromAssembly.This());

                //flightDataController = _container.Resolve<FlightController>();
            }

            _server = new HttpServer(_config);
            _client = new HttpClient(_server);

        }

        [TestMethod]
        public void FlightApi_GetAllFlightsTest()
        {
            //_client.GetAsync("http://localhost:55031/GetAllFlights").ContinueWith(task =>
            //{
            //    var response = task.Result.Content.ReadAsAsync<IEnumerable<FlightModel>>().Result;
            //    Assert.IsNotNull(response[1]);
            //});
        }

    }
}
