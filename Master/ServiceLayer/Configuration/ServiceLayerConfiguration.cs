namespace ServiceLayer.Configuration
{
    using System.Web.Http;

    public class ServiceLayerConfiguration
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

#if !DEBUG
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.LocalOnly;
#endif
            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{action}/{id}",
                new
                {
                    id = RouteParameter.Optional
                });
        }
    }
}