// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Configuration.cs" company="TractManager, Inc.">
//   Copyright © 2017
// </copyright>
// <summary>
//   Defines the Configuration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SwaggerDemo.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    using SwaggerDemo.Entities;

    /// <summary>
    /// The configuration.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<CityInfoContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        /// <summary>
        /// The seed.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        protected override void Seed(CityInfoContext context)
        {
            var cities = new List<City>
            {
                new City
                {
                    Name = "New York City",
                    Description = "The one with that big park.",
                    PointsOfInterest =
                        new List<PointOfInterest>
                        {
                            new PointOfInterest
                            {
                                Name = "Central Park",
                                Description = "The most visited urban park in the United States."
                            },
                            new PointOfInterest
                            {
                                Name = "Empire State Building",
                                Description = "A 102-story skyscraper located in Midtown Manhattan."
                            }
                        }
                },
                new City
                {
                    Name = "Antwerp",
                    Description = "The one with the cathedral that was never really finished.",
                    PointsOfInterest =
                        new List<PointOfInterest>
                        {
                            new PointOfInterest
                            {
                                Name = "Cathedral",
                                Description =
                                    "A Gothic style cathedral, conceived by architects Jan and Pieter Appelmans."
                            },
                            new PointOfInterest
                            {
                                Name = "Antwerp Central Station",
                                Description = "The the finest example of railway architecture in Belgium."
                            }
                        }
                },
                new City
                {
                    Name = "Paris",
                    Description = "The one with that big tower.",
                    PointsOfInterest =
                        new List<PointOfInterest>
                        {
                            new PointOfInterest
                            {
                                Name = "Eiffel Tower",
                                Description =
                                    "A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Eiffel."
                            },
                            new PointOfInterest { Name = "The Louvre", Description = "The world's largest museum." }
                        }
                }
            };


            context.Cities.AddRange(cities);
            context.SaveChanges();
        }
    }
}