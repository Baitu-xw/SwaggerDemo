using System.IO;
using System.Reflection;
using System.Web.Http;

using Swashbuckle.Application;

namespace SwaggerDemo
{
    public class SwaggerConfig
    {
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

        private static string GetXmlCommentsPath(Assembly assembly)
        {
            return string.Format(@"{0}\bin\{1}.XML", Directory.GetParent(System.AppDomain.CurrentDomain.RelativeSearchPath), assembly.GetName().Name);
        }
    }
}
