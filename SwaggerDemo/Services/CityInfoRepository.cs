// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CityInfoRepository.cs" company="TractManager, Inc.">
//   Copyright © 2017
// </copyright>
// <summary>
//   Defines the CityInfoRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SwaggerDemo.Services
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using SwaggerDemo.Entities;

    /// <summary>
    /// The city info repository.
    /// </summary>
    public class CityInfoRepository : ICityInfoRepository
    {
        /// <summary>
        /// The _context.
        /// </summary>
        private readonly CityInfoContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CityInfoRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public CityInfoRepository(CityInfoContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// The city exists.
        /// </summary>
        /// <param name="cityId">
        /// The city id.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool CityExists(int cityId)
        {
            return this.context.Cities.Any(c => c.Id == cityId);
        }

        /// <summary>
        /// The get cities.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<City> GetCities()
        {
            return this.context.Cities.OrderBy(c => c.Name).ToList();
        }

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
        public City GetCity(int cityId, bool includePointsOfInterest)
        {
            if (includePointsOfInterest)
                return this.context.Cities.Include(c => c.PointsOfInterest).FirstOrDefault(c => c.Id == cityId);
            return this.context.Cities.FirstOrDefault(c => c.Id == cityId);
        }

        /// <summary>
        /// The get points of interest for city.
        /// </summary>
        /// <param name="cityId">
        /// The city id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<PointOfInterest> GetPointsOfInterestForCity(int cityId)
        {
            return this.context.PointsOfInterest.Where(p => p.CityId == cityId).ToList();
        }

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
        public PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfInterestId)
        {
            return this.context.PointsOfInterest.FirstOrDefault(p => p.CityId == cityId && p.Id == pointOfInterestId);
        }

        /// <summary>
        /// The add point of interest for city.
        /// </summary>
        /// <param name="cityId">
        /// The city id.
        /// </param>
        /// <param name="pointOfInterest">
        /// The point of interest.
        /// </param>
        public void AddPointOfInterestForCity(int cityId, PointOfInterest pointOfInterest)
        {
            var city = GetCity(cityId, true);
            city.PointsOfInterest.Add(pointOfInterest);
        }

        /// <summary>
        /// The delete point of interest.
        /// </summary>
        /// <param name="pointOfInterest">
        /// The point of interest.
        /// </param>
        public void DeletePointOfInterest(PointOfInterest pointOfInterest)
        {
            this.context.PointsOfInterest.Remove(pointOfInterest);
        }

        /// <summary>
        /// The save.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Save()
        {
            return this.context.SaveChanges() >= 0;
        }
    }
}
