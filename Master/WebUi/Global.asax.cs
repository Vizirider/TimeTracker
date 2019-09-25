using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebUi
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTA5Mjc5QDMxMzcyZTMxMmUzMExtVTA5MDVxYVNoZE9iZUxzbVZNOGd1VVpzYll2Y0Q5ZGg1RTRiTk5ncmc9");
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
