using System.IO;
using System.Reflection;
using System.Web.Http;
using Swashbuckle.Application;

namespace SwaggerDemo
{
    /// <summary>
    /// The swagger config.
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// The register.
        /// </summary>
        public static void Register()
        {
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.IncludeXmlComments(GetXmlCommentsPath(typeof(SwaggerConfig).Assembly));
                    c.SingleApiVersion("v1", "SwaggerDemo");
                })
                .EnableSwaggerUi();
        }

        /// <summary>
        /// The get xml comments path.
        /// </summary>
        /// <param name="assembly">
        /// The assembly.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string GetXmlCommentsPath(Assembly assembly)
        {
            return $@"{Directory.GetParent(System.AppDomain.CurrentDomain.RelativeSearchPath)}\bin\{assembly.GetName().Name}.XML";
        }
    }
}
