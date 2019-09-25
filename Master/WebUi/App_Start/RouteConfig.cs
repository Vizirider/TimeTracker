using System.Web.Mvc;
using System.Web.Routing;
using GalaSoft.MvvmLight.Ioc;
using Server.Infrastructure.Common;
using WebUiServiceClient;
using WebUiServiceClient.Admin;
using WebUiServiceClient.Client;
using WebUiServiceClient.Permission;
using WebUiServiceClient.Project;
using WebUiServiceClient.Role;
using WebUiServiceClient.Team;
using WebUiServiceClient.TimeRecord;
using WebUiServiceClient.Todo;
using WebUiServiceClient.User;

namespace WebUi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            SimpleIoc.Default.Register<IWebUICloentCpnfiguration, WebUICloentCpnfiguration>();
            SimpleIoc.Default.Register<IUserServiceClient, UserServiceClient>();
            SimpleIoc.Default.Register<ITeamServiceClient, TeamServiceClient>();
            SimpleIoc.Default.Register<IClientServicClient, ClientServiceClient>();
            SimpleIoc.Default.Register<IProjectServiceClient, ProjectServiceClient>();
            SimpleIoc.Default.Register<IAdminServiceClient, AdminServiceClient>();
            SimpleIoc.Default.Register<IPermissionServiceClient, PermissionServiceClient>();
            SimpleIoc.Default.Register<IRoleServiceClient, RoleServiceClient>();
            SimpleIoc.Default.Register<ITodoServiceClient, TodoServiceClient>();
            SimpleIoc.Default.Register<ITimeRecordServiceClient, TimeRecordServiceClient>();


            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
