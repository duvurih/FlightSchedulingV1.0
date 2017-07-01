using System.Web.Http;

namespace FlightSchedulingProject
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Enabling cors to access services from mobile app
            config.EnableCors();

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
