using System.ComponentModel.DataAnnotations;

namespace SwaggerDemo.Models
{
    /// <summary>
    /// The point of interest for creation DTO.
    /// </summary>
    public class PointOfInterestForCreationDto
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
