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
    public class UsersController(IDomain domain) : ControllerBase
    {
        private readonly IDomain _domain = domain;

        [HttpGet]
        [SwaggerOperation(
            summary: "",
            description: "")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "", type: typeof(string), contentTypes: MediaTypeNames.Text.Plain)]
        public IActionResult TestConnection()
        {
            _domain.CoachRepository.Get();

            return Ok("Pong");
        }

        [HttpGet]
        [Route("{id}")]
        [SwaggerOperation(
            summary: "",
            description: "")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "", type: typeof(string), contentTypes: MediaTypeNames.Text.Plain)]
        public IActionResult TestConnection([FromRoute] string id)
        {
            _domain.CoachRepository.Get(id);

            return Ok("Pong");
        }
    }
}