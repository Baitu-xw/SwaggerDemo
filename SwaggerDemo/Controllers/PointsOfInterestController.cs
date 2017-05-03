// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PointsOfInterestController.cs" company="TractManager, Inc.">
//   Copyright © 2017
// </copyright>
// <summary>
//   Points of interest controller
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SwaggerDemo.Controllers
{
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
            this.cityInfoRepository = this.cityInfoRepository = IocContainer.Instance.Resolve<ICityInfoRepository>();
        }

        /// <summary>
        /// The get points of interest.
        /// </summary>
        /// <param name="cityId">
        /// The city id.
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
                if (!this.cityInfoRepository.CityExists(cityId))
                {
                    StatusCode(HttpStatusCode.NotFound);
                }

                return Ok(Mapper.Map<IEnumerable<PointOfInterestDto>>(this.cityInfoRepository.GetPointsOfInterestForCity(cityId)));
            }
            catch (Exception e)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            
        }

        /// <summary>
        /// The get point of interest.
        /// </summary>
        /// <param name="cityId">
        /// The city id.
        /// </param>
        /// <param name="poiId">
        /// The poi id.
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
            if (!this.cityInfoRepository.CityExists(cityId)) StatusCode(HttpStatusCode.NotFound);

            var pointOfInterestFromDb = this.cityInfoRepository.GetPointOfInterestForCity(cityId, poiId);
            if (pointOfInterestFromDb == null) StatusCode(HttpStatusCode.NotFound);

            return Ok(Mapper.Map<PointOfInterestDto>(pointOfInterestFromDb));
        }

        /// <summary>
        /// The create point of interest.
        /// </summary>
        /// <param name="cityId">
        /// The city id.
        /// </param>
        /// <param name="pointOfInterest">
        /// The point of interest.
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
            if (pointOfInterest == null) return BadRequest();

            if (pointOfInterest.Description == pointOfInterest.Name)
                ModelState.AddModelError("Description", "Description should not be equal to name");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!this.cityInfoRepository.CityExists(cityId)) StatusCode(HttpStatusCode.NotFound);

            var pointToCreate = Mapper.Map<PointOfInterest>(pointOfInterest);
            this.cityInfoRepository.AddPointOfInterestForCity(cityId, pointToCreate);

            if (!this.cityInfoRepository.Save()) return StatusCode(HttpStatusCode.InternalServerError);

            var createdPointOfInterest = Mapper.Map<PointOfInterestDto>(pointToCreate);

            return Created(Request.RequestUri + "/" + createdPointOfInterest.Id, createdPointOfInterest);
        }

        /// <summary>
        /// The update point of interest.
        /// </summary>
        /// <param name="cityId">
        /// The city id.
        /// </param>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="pointOfInterest">
        /// The point of interest.
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
            int id,
            [FromBody] PointOfInterestForCreationDto pointOfInterest)
        {
            if (pointOfInterest == null) return BadRequest();

            if (pointOfInterest.Description == pointOfInterest.Name)
                ModelState.AddModelError("Description", "Description should not be equal to name");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!this.cityInfoRepository.CityExists(cityId)) StatusCode(HttpStatusCode.NotFound);

            var pointToUpdate = this.cityInfoRepository.GetPointOfInterestForCity(cityId, id);
            if (pointToUpdate == null) StatusCode(HttpStatusCode.NotFound);

            Mapper.Map(pointOfInterest, pointToUpdate);

            if (!this.cityInfoRepository.Save()) return StatusCode(HttpStatusCode.InternalServerError);

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// The delete point of action.
        /// </summary>
        /// <param name="cityId">
        /// The city id.
        /// </param>
        /// <param name="poiId">
        /// The poi id.
        /// </param>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        [HttpDelete]
        [Route("cities/{cityId}/pointsofinterest/{poiId}")]
        [SwaggerResponse(204, "No content", typeof(StatusCodeResult))]
        [SwaggerResponse(404, "Not found", typeof(NotFoundResult))]
        [SwaggerResponse(500, "Error occurred while processing your request", typeof(InternalServerErrorResult))]
        public IHttpActionResult DeletePointOfAction(int cityId, int poiId)
        {
            if (!this.cityInfoRepository.CityExists(cityId)) return StatusCode(HttpStatusCode.NotFound);

            var pointEntity = this.cityInfoRepository.GetPointOfInterestForCity(cityId, poiId);
            if (pointEntity == null) return StatusCode(HttpStatusCode.NotFound);

            this.cityInfoRepository.DeletePointOfInterest(pointEntity);
            if (!this.cityInfoRepository.Save()) return StatusCode(HttpStatusCode.InternalServerError);

            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}
