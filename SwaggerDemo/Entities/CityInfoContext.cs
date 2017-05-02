// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CityInfoContext.cs" company="TractManager, Inc.">
//   Copyright © 2017
// </copyright>
// <summary>
//   Defines the CityInfoContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SwaggerDemo.Entities
{
    using System.Data.Entity;

    /// <summary>
    /// The city info context.
    /// </summary>
    public sealed class CityInfoContext : DbContext
    {
        /// <summary>
        /// Gets or sets the cities.
        /// </summary>
        public DbSet<City> Cities { get; set; }

        /// <summary>
        /// Gets or sets the points of interest.
        /// </summary>
        public DbSet<PointOfInterest> PointsOfInterest { get; set; }
    }
}