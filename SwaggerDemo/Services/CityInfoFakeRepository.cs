using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SwaggerDemo.Entities;

namespace SwaggerDemo.Services
{
    /// <summary>
    /// The city info fake repository.
    /// </summary>
    public class CityInfoFakeRepository : ICityInfoRepository
    {
        /// <summary>
        /// The cities.
        /// </summary>
        private List<City> cities;

        /// <summary>
        /// Initializes a new instance of the <see cref="CityInfoFakeRepository"/> class.
        /// </summary>
        public CityInfoFakeRepository()
        {
            cities = new List<City>
            {
                new City
                {
                    Id = 1,
                    Name = "New York City",
                    Description = "The one with that big park.",
                    PointsOfInterest =
                        new List<PointOfInterest>
                        {
                            new PointOfInterest
                            {
                                Id = 1,
                                Name = "Central Park",
                                Description = "The most visited urban park in the United States."
                            },
                            new PointOfInterest
                            {
                                Id = 2,
                                Name = "Empire State Building",
                                Description = "A 102-story skyscraper located in Midtown Manhattan."
                            }
                        }
                },
                new City
                {
                    Id = 2,
                    Name = "Antwerp",
                    Description = "The one with the cathedral that was never really finished.",
                    PointsOfInterest =
                        new List<PointOfInterest>
                        {
                            new PointOfInterest
                            {
                                Id = 3,
                                Name = "Cathedral",
                                Description =
                                    "A Gothic style cathedral, conceived by architects Jan and Pieter Appelmans."
                            },
                            new PointOfInterest
                            {
                                Id = 4,
                                Name = "Antwerp Central Station",
                                Description = "The the finest example of railway architecture in Belgium."
                            }
                        }
                },
                new City
                {
                    Id = 3,
                    Name = "Paris",
                    Description = "The one with that big tower.",
                    PointsOfInterest =
                        new List<PointOfInterest>
                        {
                            new PointOfInterest
                            {
                                Id = 5,
                                Name = "Eiffel Tower",
                                Description =
                                    "A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Eiffel."
                            },
                            new PointOfInterest
                            {
                                Id = 6,
                                Name = "The Louvre",
                                Description = "The world's largest museum."
                            }
                        }
                }
            };
        }

        /// <summary>
        /// The save.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Save()
        {
            return true;
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
            return cities.Any(c => c.Id == cityId);
        }

        /// <summary>
        /// The get cities.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<City> GetCities()
        {
            return cities;
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
            return cities.FirstOrDefault(c => c.Id == cityId);
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
            return cities.FirstOrDefault(c => c.Id == cityId)?.PointsOfInterest;
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
            return
                cities.FirstOrDefault(c => c.Id == cityId)?.PointsOfInterest.FirstOrDefault(p => p.Id == pointOfInterestId);
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
            cities.FirstOrDefault(c => c.Id == cityId)?.PointsOfInterest.Add(pointOfInterest);
        }

        /// <summary>
        /// The delete point of interest.
        /// </summary>
        /// <param name="pointOfInterest">
        /// The point of interest.
        /// </param>
        public void DeletePointOfInterest(PointOfInterest pointOfInterest)
        {
            foreach (var city in cities)
            {
                if (city.PointsOfInterest.Contains(pointOfInterest))
                {
                    city.PointsOfInterest.Remove(pointOfInterest);
                }
            }
        }
    }
}