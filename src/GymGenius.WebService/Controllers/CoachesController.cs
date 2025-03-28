using GymGenius.DataAccess.Models;
using GymGenius.Domain;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

using System.Net.Mime;

namespace GymGenius.WebService.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    [SwaggerTag(description: "")]
    public class CoachesController(IDomain domain) : ControllerBase
    {
        private readonly IDomain _domain = domain;

        [HttpGet]
        [SwaggerOperation(
            summary: "",
            description: "")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "", type: typeof(string), contentTypes: MediaTypeNames.Text.Plain)]
        public IActionResult Get()
        {
            var coaches = _domain.CoachRepository.Get() ?? [];
            return Ok(coaches);
        }

        [HttpGet, Route("{id}")]
        [SwaggerOperation(
            summary: "",
            description: "")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "", type: typeof(string), contentTypes: MediaTypeNames.Text.Plain)]
        public IActionResult Get(string id)
        {
            var coach = _domain.CoachRepository.Get(id);
            return Ok(coach);
        }

        [HttpPost]
        [SwaggerOperation(
            summary: "",
            description: "")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "", type: typeof(string), contentTypes: MediaTypeNames.Text.Plain)]
        public IActionResult New([FromBody] CoachModel coachModel)
        {
            var isSuccess = _domain.CoachRepository.NewEntity(coachModel);
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
            var isSuccess = _domain.CoachRepository.RemoveEntity(id);
            var statusCode = isSuccess ? StatusCodes.Status204NoContent : StatusCodes.Status400BadRequest;


            return new StatusCodeResult(statusCode);
        }


        [HttpPost, Route("{id}")]
        [SwaggerOperation(
            summary: "Update",
            description: "")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "", type: typeof(string), contentTypes: MediaTypeNames.Text.Plain)]
        public IActionResult Update(CoachModel coachmodel)
        {
            var coach = _domain.CoachRepository.UpdateEntity(coachmodel);
            return Ok(coach);
        }
    }
}
