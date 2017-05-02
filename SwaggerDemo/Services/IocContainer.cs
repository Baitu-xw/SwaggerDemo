// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IocContainer.cs" company="TractManager, Inc.">
//   Copyright © 2017
// </copyright>
// <summary>
//   Defines the IocContainer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SwaggerDemo.Services
{
    using Microsoft.Practices.Unity;

    /// <summary>
    /// The IoC container.
    /// </summary>
    public sealed class IocContainer : UnityContainer
    {

        /// <summary>
        /// The sync root.
        /// </summary>
        private static readonly object SyncRoot = new object();

        /// <summary>
        /// The _instance.
        /// </summary>
        private static volatile IocContainer instance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static IocContainer Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new IocContainer();
                        }
                    }
                }

                return instance;
            }
        }
    }
}