/*
 * MIS.Back
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using ApiProject.Attributes;
using ApiProject.Security;
using Microsoft.AspNetCore.Authorization;
using ApiProject.Models;
using ApiProject.Services;

namespace ApiProject.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class DictionaryApiController(IDictionaryApiService dictionaryService) : ControllerBase
    {
        /// <summary>
        /// Search for diagnoses in ICD-10 dictionary
        /// </summary>
        /// <param name="request">part of the diagnosis name or code</param>
        /// <param name="page">page number</param>
        /// <param name="size">required number of elements per page</param>
        /// <response code="200">Searching result extracted</response>
        /// <response code="400">Some fields in request are invalid</response>
        /// <response code="500">InternalServerError</response>
        [HttpGet]
        [Route("/api/dictionary/icd10")]
        [ValidateModelState]
        [SwaggerOperation("ApiDictionaryIcd10Get")]
        [SwaggerResponse(statusCode: 200, type: typeof(Icd10SearchModel), description: "Searching result extracted")]
        [SwaggerResponse(statusCode: 500, type: typeof(ResponseModel), description: "InternalServerError")]
        public virtual IActionResult ApiDictionaryIcd10Get([FromQuery] string request, [FromQuery][Range(1, 2147483647)] int? page, [FromQuery][Range(1, 2147483647)] int? size)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Icd10SearchModel));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 500 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(500, default(ResponseModel));
            string exampleJson = null;
            exampleJson = "{\n  \"pagination\" : {\n    \"current\" : 1,\n    \"size\" : 0,\n    \"count\" : 6\n  },\n  \"records\" : [ {\n    \"code\" : \"code\",\n    \"createTime\" : \"2000-01-23T04:56:07.000+00:00\",\n    \"name\" : \"name\",\n    \"id\" : \"046b6c7f-0b8a-43b9-b35d-6489e6daee91\"\n  }, {\n    \"code\" : \"code\",\n    \"createTime\" : \"2000-01-23T04:56:07.000+00:00\",\n    \"name\" : \"name\",\n    \"id\" : \"046b6c7f-0b8a-43b9-b35d-6489e6daee91\"\n  } ]\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Icd10SearchModel>(exampleJson)
            : default(Icd10SearchModel);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Get root ICD-10 elements
        /// </summary>
        /// <response code="200">Root ICD-10 elements retrieved</response>
        /// <response code="500">InternalServerError</response>
        [HttpGet]
        [Route("/api/dictionary/icd10/roots")]
        [ValidateModelState]
        [SwaggerOperation("ApiDictionaryIcd10RootsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Icd10RecordModel>), description: "Root ICD-10 elements retrieved")]
        [SwaggerResponse(statusCode: 500, type: typeof(ResponseModel), description: "InternalServerError")]
        public virtual IActionResult ApiDictionaryIcd10RootsGet()
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<Icd10RecordModel>));

            //TODO: Uncomment the next line to return response 500 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(500, default(ResponseModel));
            string exampleJson = null;
            exampleJson = "[ {\n  \"code\" : \"code\",\n  \"createTime\" : \"2000-01-23T04:56:07.000+00:00\",\n  \"name\" : \"name\",\n  \"id\" : \"046b6c7f-0b8a-43b9-b35d-6489e6daee91\"\n}, {\n  \"code\" : \"code\",\n  \"createTime\" : \"2000-01-23T04:56:07.000+00:00\",\n  \"name\" : \"name\",\n  \"id\" : \"046b6c7f-0b8a-43b9-b35d-6489e6daee91\"\n} ]";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<Icd10RecordModel>>(exampleJson)
            : default(List<Icd10RecordModel>);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Get specialties list
        /// </summary>
        /// <param name="name">part of the name for filtering</param>
        /// <param name="page">page number</param>
        /// <param name="size">required number of elements per page</param>
        /// <response code="200">Specialties paged list retrieved</response>
        /// <response code="400">Invalid arguments for filtration/pagination</response>
        /// <response code="500">InternalServerError</response>
        [HttpGet]
        [Route("/api/dictionary/speciality")]
        [ValidateModelState]
        [SwaggerOperation("ApiDictionarySpecialityGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(SpecialtiesPagedListModel), description: "Specialties paged list retrieved")]
        [SwaggerResponse(statusCode: 500, type: typeof(ResponseModel), description: "InternalServerError")]
        public virtual async Task<IActionResult> ApiDictionarySpecialityGet([FromQuery] string? name, [FromQuery][Range(1, 2147483647)] int? page, [FromQuery][Range(1, 2147483647)] int? size)
        {
            try
            {
                SpecialtiesPagedListModel pageList = await dictionaryService.GetSpeciality(name = name, size = size, page = page);
                return Ok(pageList);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"{e.Message}");
            }
        }

        /// <summary>
        /// Create Speciality
        /// </summary>
        /// <param name="specialityAddModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/dictionary/speciality")]
        [ValidateModelState]
        [SwaggerOperation("ApiDictionarySpecialityPost")]
        // TokenResponseModel 
        [SwaggerResponse(statusCode: 200, type: typeof(TokenResponseModel), description: "Specialties  retrieved")]
        [SwaggerResponse(statusCode: 500, type: typeof(ResponseModel), description: "InternalServerError")]
        public virtual async Task<IActionResult> ApiDictionarySpecialityPost([FromBody] SpecialityAddModel specialityAddModel)
        {
            try
            {
                string value = (await dictionaryService.CreateSpeciality(specialityAddModel)).ToString();
                return Ok(new {SpecialityId = value});
            }
            catch (Exception e)
            {
                return StatusCode(500, $"{e.Message}");
            }
        }
    }
}
