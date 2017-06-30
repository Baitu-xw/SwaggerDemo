using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using AutoMapper;
using Microsoft.Practices.Unity;
using SwaggerDemo.Models;
using SwaggerDemo.Services;
using Swashbuckle.Swagger.Annotations;

namespace SwaggerDemo.Controllers
{
    /// <summary>
    /// Cities controller
    /// </summary>
    [RoutePrefix("api")]
    public class CitiesController : ApiController
    {
        /// <summary>
        /// The city info repository.
        /// </summary>
        private readonly ICityInfoRepository cityInfoRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CitiesController"/> class. 
        /// </summary>
        public CitiesController()
        {
            cityInfoRepository = IocContainer.Instance.Resolve<ICityInfoRepository>();
        }

        /// <summary>
        /// Get cities without points of interest.
        /// </summary>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        [HttpGet]
        [Route("cities")]
        [SwaggerResponse(200, "Ok", typeof(IEnumerable<CityWithoutPointsOfInterestDto>))]
        [SwaggerResponse(500, "Error occurred while processing your request", typeof(InternalServerErrorResult))]
        public IHttpActionResult GetCities()
        {
            return Ok(Mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityInfoRepository.GetCities()));
        }

        /// <summary>
        /// Get city with or without point of interest.
        /// </summary>
        /// <param name="cityId">
        /// Id of city.
        /// </param>
        /// <param name="includePointsOfInterest">
        /// Flag to include points of interest.
        /// </param>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        [HttpGet]
        [Route("cities/{cityId}")]
        [SwaggerResponse(200, "Ok", typeof(CityDto))]
        [SwaggerResponse(404, "Not found", typeof(NotFoundResult))]
        [SwaggerResponse(500, "Error occurred while processing your request", typeof(InternalServerErrorResult))]
        public IHttpActionResult GetCity(int cityId, bool includePointsOfInterest = false)
        {
            var city = cityInfoRepository.GetCity(cityId, includePointsOfInterest);
            if (city == null)
            {
                return NotFound();
            }

            if (includePointsOfInterest)
            {
                return Ok(Mapper.Map<CityDto>(city));
            }

            return Ok(Mapper.Map<CityWithoutPointsOfInterestDto>(city));
        }
    }
}
