namespace SwaggerDemo
{
    using System.Data.Entity;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;

    using SwaggerDemo.Services;

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            SwaggerConfig.Register();
            Database.SetInitializer(new DatabaseInitializer());
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            UnityConfig.RegisterTypes(IocContainer.Instance);
            AutomapperConfig.RegisterTypes();
        }
    }
}