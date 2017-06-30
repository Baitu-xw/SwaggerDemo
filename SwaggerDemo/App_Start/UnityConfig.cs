using Microsoft.Practices.Unity;
using SwaggerDemo.Services;

namespace SwaggerDemo
{
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
            container.RegisterType<ICityInfoRepository, CityInfoFakeRepository>(
                new ContainerControlledLifetimeManager(),
                new InjectionFactory(_ => new CityInfoFakeRepository()));
        }
    }
}