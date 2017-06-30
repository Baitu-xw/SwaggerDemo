using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using AutoMapper;
using Microsoft.Practices.Unity;
using SwaggerDemo.Entities;
using SwaggerDemo.Models;
using SwaggerDemo.Services;
using Swashbuckle.Swagger.Annotations;

namespace SwaggerDemo.Controllers
{
    /// <summary>
    /// Points of interest controller
    /// </summary>
    [RoutePrefix("api")]
    public class PointsOfInterestController : ApiController
    {
        /// <summary>
        /// The city info repository.
        /// </summary>
        private readonly ICityInfoRepository cityInfoRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PointsOfInterestController"/> class.
        /// </summary>
        public PointsOfInterestController()
        {
            cityInfoRepository = cityInfoRepository = IocContainer.Instance.Resolve<ICityInfoRepository>();
        }

        /// <summary>
        /// Get all points of interest for specified city.
        /// </summary>
        /// <param name="cityId">
        /// Id of city.
        /// </param>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        [HttpGet]
        [Route("cities/{cityId}/pointsofinterest")]
        [SwaggerResponse(200, "Ok", typeof(IEnumerable<PointOfInterestDto>))]
        [SwaggerResponse(404, "Not found", typeof(NotFoundResult))]
        [SwaggerResponse(500, "Error occurred while processing your request", typeof(InternalServerErrorResult))]
        public IHttpActionResult GetPointsOfInterest(int cityId)
        {
            try
            {
                if (!cityInfoRepository.CityExists(cityId))
                {
                    return NotFound();
                }

                return
                    Ok(
                        Mapper.Map<IEnumerable<PointOfInterestDto>>(
                            cityInfoRepository.GetPointsOfInterestForCity(cityId)));
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        /// <summary>
        /// Get point of interest for specified city
        /// </summary>
        /// <param name="cityId">
        /// Id of city.
        /// </param>
        /// <param name="poiId">
        /// Id of point of interest.
        /// </param>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        [HttpGet]
        [Route("cities/{cityId}/pointsofinterest/{poiId}", Name = "GetPointOfInterest")]
        [SwaggerResponse(200, "Ok", typeof(PointOfInterestDto))]
        [SwaggerResponse(404, "Not found", typeof(NotFoundResult))]
        [SwaggerResponse(500, "Error occurred while processing your request", typeof(InternalServerErrorResult))]
        public IHttpActionResult GetPointOfInterest(int cityId, int poiId)
        {
            if (!cityInfoRepository.CityExists(cityId))
            {
                return NotFound();
            }

            var pointOfInterestFromDb = cityInfoRepository.GetPointOfInterestForCity(cityId, poiId);
            if (pointOfInterestFromDb == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<PointOfInterestDto>(pointOfInterestFromDb));
        }

        /// <summary>
        /// Create point of interest for specified city
        /// </summary>
        /// <param name="cityId">
        /// Id of city.
        /// </param>
        /// <param name="pointOfInterest">
        /// Point of interest to create.
        /// </param>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        [HttpPost]
        [Route("cities/{cityId}/pointsofinterest")]
        [SwaggerResponse(200, "Ok", typeof(PointOfInterestDto))]
        [SwaggerResponse(404, "Not found", typeof(NotFoundResult))]
        [SwaggerResponse(500, "Error occurred while processing your request", typeof(InternalServerErrorResult))]
        public IHttpActionResult CreatePointOfInterest(
            int cityId,
            [FromBody] PointOfInterestForCreationDto pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }

            if (pointOfInterest.Description == pointOfInterest.Name)
            {
                ModelState.AddModelError("Description", "Description should not be equal to name");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!cityInfoRepository.CityExists(cityId))
            {
                return NotFound();
            }

            var pointToCreate = Mapper.Map<PointOfInterest>(pointOfInterest);
            cityInfoRepository.AddPointOfInterestForCity(cityId, pointToCreate);

            if (!cityInfoRepository.Save())
            {
                return InternalServerError(new Exception("Failed to save changes into database"));
            }

            var createdPointOfInterest = Mapper.Map<PointOfInterestDto>(pointToCreate);

            return Created(Request.RequestUri + "/" + createdPointOfInterest.Id, createdPointOfInterest);
        }

        /// <summary>
        /// Update point of interest for specified city.
        /// </summary>
        /// <param name="cityId">
        /// Id of city.
        /// </param>
        /// <param name="poiId">
        /// Id of point of interest.
        /// </param>
        /// <param name="pointOfInterest">
        /// Resulting point of interest.
        /// </param>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        [HttpPut]
        [Route("cities/{cityId}/pointsofinterest/{poiId}")]
        [SwaggerResponse(204, "No content", typeof(StatusCodeResult))]
        [SwaggerResponse(404, "Not found", typeof(NotFoundResult))]
        [SwaggerResponse(500, "Error occurred while processing your request", typeof(InternalServerErrorResult))]
        public IHttpActionResult UpdatePointOfInterest(
            int cityId,
            int poiId,
            [FromBody] PointOfInterestForCreationDto pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }

            if (pointOfInterest.Description == pointOfInterest.Name)
            {
                ModelState.AddModelError("Description", "Description should not be equal to name");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!cityInfoRepository.CityExists(cityId))
            {
                return NotFound();
            }

            var pointToUpdate = cityInfoRepository.GetPointOfInterestForCity(cityId, poiId);
            if (pointToUpdate == null)
            {
                return NotFound();
            }

            Mapper.Map(pointOfInterest, pointToUpdate);

            if (!cityInfoRepository.Save())
            {
                return InternalServerError(new Exception("Failed to save changes into database"));
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Delete point of interest for specified city.
        /// </summary>
        /// <param name="cityId">
        /// Id of city.
        /// </param>
        /// <param name="poiId">
        /// Id of point of interest.
        /// </param>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        [HttpDelete]
        [Route("cities/{cityId}/pointsofinterest/{poiId}")]
        [SwaggerResponse(204, "No content", typeof(void))]
        [SwaggerResponse(404, "Not found", typeof(NotFoundResult))]
        [SwaggerResponse(500, "Error occurred while processing your request", typeof(InternalServerErrorResult))]
        public IHttpActionResult DeletePointOfInterest(int cityId, int poiId)
        {
            if (!cityInfoRepository.CityExists(cityId))
            {
                return NotFound();
            }

            var pointEntity = cityInfoRepository.GetPointOfInterestForCity(cityId, poiId);
            if (pointEntity == null)
            {
                return NotFound();
            }

            cityInfoRepository.DeletePointOfInterest(pointEntity);
            if (!cityInfoRepository.Save())
            {
                return InternalServerError(new Exception("Failed to save changes into database"));
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
