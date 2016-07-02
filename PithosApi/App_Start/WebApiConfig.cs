using System.Net.Http.Headers;
using System.Web.Http;

namespace PithosApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            // Web API configuration and services
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            // Web API routes
            config.MapHttpAttributeRoutes();

            
        }
    }
}
