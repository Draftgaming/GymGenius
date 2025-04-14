using GymGenius.DataAccess.Models;
using GymGenius.Domain;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

using System.Net.Mime;

namespace GymGenius.WebService.Controllers
{
    //TODO the people update delete and new are not working 
    [ApiController]
    [Route("/api/v1/[controller]")]
    [SwaggerTag(description: "")]
    public class PeopleController(IDomain domain) : ControllerBase
    {
        private readonly IDomain _domain = domain;

        [HttpGet]
        [SwaggerOperation(
            summary: "",
            description: "")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "", type: typeof(string), contentTypes: MediaTypeNames.Text.Plain)]
        public IActionResult Get()
        {
            var Peoples = _domain.PeopleRepository.Get() ?? [];
            return Ok(Peoples);
        }

        [HttpGet, Route("{id}")]
        [SwaggerOperation(
            summary: "",
            description: "")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "", type: typeof(string), contentTypes: MediaTypeNames.Text.Plain)]
        public IActionResult Get(string id)
        {
            var People = _domain.PeopleRepository.Get(id);
            return Ok(People);
        }

        [HttpPost]
        [SwaggerOperation(
            summary: "",
            description: "")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "", type: typeof(string), contentTypes: MediaTypeNames.Text.Plain)]
        public IActionResult New([FromBody] PeopleModel PeopleModel)
        {
            var isSuccess = _domain.PeopleRepository.NewEntity(PeopleModel);
            var statusCode = isSuccess ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest;


            return new StatusCodeResult(statusCode);
        }

        [HttpDelete, Route("{id}")]
        [SwaggerOperation(
            summary: "",
            description: "")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "", type: typeof(string), contentTypes: MediaTypeNames.Text.Plain)]
        public IActionResult Remove(string id)
        {
            var isSuccess = _domain.PeopleRepository.RemoveEntity(id);
            var statusCode = isSuccess
                ? StatusCodes.Status204NoContent
                : StatusCodes.Status400BadRequest;

            return new StatusCodeResult(statusCode);
        }


        [HttpPut, Route("{id}")]
        [SwaggerOperation(
            summary: "Update",
            description: "")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "", type: typeof(string), contentTypes: MediaTypeNames.Text.Plain)]
        public IActionResult Update(string id, PeopleModel Peoplemodel)
        {
            var isGoodRequest = long.TryParse(id, out long idOut);

            if (!isGoodRequest)
            {
                return BadRequest("Invalid ID format.");
            }

            Peoplemodel.PeopleId = idOut;
            var isSuccess = _domain.PeopleRepository.UpdateEntity(Peoplemodel);

            var statusCode = isSuccess
                ? StatusCodes.Status204NoContent
                : StatusCodes.Status400BadRequest;

            return new StatusCodeResult(statusCode);
        }
    }
}
