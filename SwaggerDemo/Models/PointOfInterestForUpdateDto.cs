// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PointOfInterestForUpdateDto.cs" company="TractManager, Inc.">
//   Copyright © 2017
// </copyright>
// <summary>
//   Point of interest for update
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SwaggerDemo.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The point of interest for update DTO.
    /// </summary>
    public class PointOfInterestForUpdateDto
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required(ErrorMessage = "Your should provide a name value")]
        [MaxLength(64)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [MaxLength(256)]
        public string Description { get; set; }
    }
}
