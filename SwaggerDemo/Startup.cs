using Microsoft.Owin;
using Owin;
using SwaggerDemo;

[assembly: OwinStartup(typeof(Startup))]

namespace SwaggerDemo
{
    /// <summary>
    /// The startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// The configuration.
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
