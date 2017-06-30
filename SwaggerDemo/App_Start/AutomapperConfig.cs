using AutoMapper;
using SwaggerDemo.Entities;
using SwaggerDemo.Models;

namespace SwaggerDemo
{
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
                cfg.CreateMap<City, CityWithoutPointsOfInterestDto>();
                cfg.CreateMap<City, CityDto>();
                cfg.CreateMap<PointOfInterest, PointOfInterestDto>();
                cfg.CreateMap<PointOfInterestForCreationDto, PointOfInterest>();
                cfg.CreateMap<PointOfInterestForUpdateDto, PointOfInterest>();
                cfg.CreateMap<PointOfInterest, PointOfInterestForUpdateDto>();
            });
        }
    }
}
