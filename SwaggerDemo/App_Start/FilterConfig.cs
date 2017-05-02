// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilterConfig.cs" company="TractManager, Inc.">
//   Copyright © 2017
// </copyright>
// <summary>
//   Defines the FilterConfig type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SwaggerDemo
{
    using System.Web.Mvc;

    /// <summary>
    /// The filter config.
    /// </summary>
    public static class FilterConfig
    {
        /// <summary>
        /// The register global filters.
        /// </summary>
        /// <param name="filters">
        /// The filters.
        /// </param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
