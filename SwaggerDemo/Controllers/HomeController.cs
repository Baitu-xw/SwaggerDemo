// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="TractManager, Inc.">
//   Copyright © 2017
// </copyright>
// <summary>
//   The home controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SwaggerDemo.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// The home controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            return new RedirectResult("~/swagger/ui/index");
        }
    }
}