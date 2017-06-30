// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="TractManager, Inc.">
//   Copyright © 2017
// </copyright>
// <summary>
//   Defines the WebApiApplication type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using SwaggerDemo.Services;

namespace SwaggerDemo
{
    /// <summary>
    /// The web API application.
    /// </summary>
    public class WebApiApplication : HttpApplication
    {
        /// <summary>
        /// The application_ start.
        /// </summary>
        protected void Application_Start()
        {
            SwaggerConfig.Register();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            UnityConfig.RegisterTypes(IocContainer.Instance);
            AutomapperConfig.RegisterTypes();
        }
    }
}