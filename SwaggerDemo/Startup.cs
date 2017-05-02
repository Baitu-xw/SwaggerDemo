// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="TractManager, Inc.">
//   Copyright © 2017
// </copyright>
// <summary>
//   Defines the Startup type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Owin;

using SwaggerDemo;

[assembly: OwinStartup(typeof(Startup))]

namespace SwaggerDemo
{
    using Owin;

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
