using System.Collections.Generic;

namespace SwaggerDemo.Models
{
    /// <summary>
    /// City object with points of interest
    /// </summary>
    public class CityDto
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

        /// <summary>
        /// The number of points of interest.
        /// </summary>
        public int NumberOfPointsOfInterest => PointsOfInterest.Count;

        /// <summary>
        /// Gets or sets the points of interest.
        /// </summary>
        public ICollection<PointOfInterestDto> PointsOfInterest { get; set; } = new List<PointOfInterestDto>();
    }
}
