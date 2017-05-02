// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CityWithoutPointsOfInterestDto.cs" company="TractManager, Inc.">
//   Copyright © 2017
// </copyright>
// <summary>
//   City without points of interest
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SwaggerDemo.Models
{
    /// <summary>
    /// The city without points of interest DTO.
    /// </summary>
    public abstract class CityWithoutPointsOfInterestDto
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }
    }
}
