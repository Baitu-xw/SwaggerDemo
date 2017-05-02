// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnityConfig.cs" company="TractManager, Inc.">
//   Copyright © 2017
// </copyright>
// <summary>
//   Defines the UnityConfig type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SwaggerDemo
{
    using Microsoft.Practices.Unity;

    using SwaggerDemo.Entities;
    using SwaggerDemo.Services;

    /// <summary>
    /// The unity config.
    /// </summary>
    public static class UnityConfig
    {
        /// <summary>
        /// The register types.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public static void RegisterTypes(IUnityContainer container)
        {
            // Win App Driver
            container.RegisterType<ICityInfoRepository, CityInfoRepository>(
                new ContainerControlledLifetimeManager(),
                new InjectionFactory(_ => new CityInfoRepository(new CityInfoContext())));
        }
    }
}