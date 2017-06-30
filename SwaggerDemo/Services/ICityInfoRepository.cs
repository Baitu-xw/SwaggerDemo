using System.Collections;
using System.Collections.Generic;
using SwaggerDemo.Entities;

namespace SwaggerDemo.Services
{
    /// <summary>
    /// The CityInfoRepository interface.
    /// </summary>
    public interface ICityInfoRepository
    {
        /// <summary>
        /// The save.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool Save();

        /// <summary>
        /// The city exists.
        /// </summary>
        /// <param name="cityId">
        /// The city id.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool CityExists(int cityId);

        /// <summary>
        /// The get cities.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<City> GetCities();

        /// <summary>
        /// The get city.
        /// </summary>
        /// <param name="cityId">
        /// The city id.
        /// </param>
        /// <param name="includePointsOfInterest">
        /// The include points of interest.
        /// </param>
        /// <returns>
        /// The <see cref="City"/>.
        /// </returns>
        City GetCity(int cityId, bool includePointsOfInterest);

        /// <summary>
        /// The get points of interest for city.
        /// </summary>
        /// <param name="cityId">
        /// The city id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<PointOfInterest> GetPointsOfInterestForCity(int cityId);

        /// <summary>
        /// The get point of interest for city.
        /// </summary>
        /// <param name="cityId">
        /// The city id.
        /// </param>
        /// <param name="pointOfInterestId">
        /// The point of interest id.
        /// </param>
        /// <returns>
        /// The <see cref="PointOfInterest"/>.
        /// </returns>
        PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfInterestId);

        /// <summary>
        /// The add point of interest for city.
        /// </summary>
        /// <param name="cityId">
        /// The city id.
        /// </param>
        /// <param name="pointOfInterest">
        /// The point of interest.
        /// </param>
        void AddPointOfInterestForCity(int cityId, PointOfInterest pointOfInterest);

        /// <summary>
        /// The delete point of interest.
        /// </summary>
        /// <param name="pointOfInterest">
        /// The point of interest.
        /// </param>
        void DeletePointOfInterest(PointOfInterest pointOfInterest);
    }
}
