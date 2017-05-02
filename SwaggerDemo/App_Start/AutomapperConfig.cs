// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutomapperConfig.cs" company="TractManager, Inc.">
//   Copyright © 2017
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace SwaggerDemo
{
    using AutoMapper;

    using SwaggerDemo.Entities;
    using SwaggerDemo.Models;

    /// <summary>
    /// The AutoMapper config.
    /// </summary>
    public static class AutomapperConfig
    {
        /// <summary>
        /// The register types.
        /// </summary>
        public static void RegisterTypes()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<City, CityWithoutPointsOfInterestDto>().ReverseMap();
                cfg.CreateMap<City, CityDto>();
                cfg.CreateMap<PointOfInterest, PointOfInterestDto>();
                cfg.CreateMap<PointOfInterestForCreationDto, PointOfInterest>();
                cfg.CreateMap<PointOfInterestForUpdateDto, PointOfInterest>();
                cfg.CreateMap<PointOfInterest, PointOfInterestForUpdateDto>();
            });
        }
    }
}
