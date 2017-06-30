using System.Web.Mvc;

namespace SwaggerDemo.Controllers
{
    /// <summary>
    /// Home controller to open swagger UI as default page.
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