using GymGenius.DataAccess.Models;
using GymGenius.Domain;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

using System.Net.Mime;

namespace GymGenius.WebService.Controllers
{
    //TODO the get dont give the all the values 
    [ApiController]
    [Route("/api/v1/[controller]")]
    [SwaggerTag(description: "")]
    public class PlansController(IDomain domain) : ControllerBase
    {
        private readonly IDomain _domain = domain;

        [HttpGet]
        [SwaggerOperation(
            summary: "",
            description: "")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "", type: typeof(string), contentTypes: MediaTypeNames.Text.Plain)]
        public IActionResult Get()
        {
            var Plans = _domain.PlanRepository.Get() ?? [];
            return Ok(Plans);
        }

        [HttpGet, Route("{id}")]
        [SwaggerOperation(
            summary: "",
            description: "")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "", type: typeof(string), contentTypes: MediaTypeNames.Text.Plain)]
        public IActionResult Get(string id)
        {
            var Plan = _domain.PlanRepository.Get(id);
            return Ok(Plan);
        }

        [HttpPost]
        [SwaggerOperation(
            summary: "",
            description: "")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "", type: typeof(string), contentTypes: MediaTypeNames.Text.Plain)]
        public IActionResult New([FromBody] PlanModel PlanModel)
        {
            var isSuccess = _domain.PlanRepository.NewEntity(PlanModel);
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
            var isSuccess = _domain.PlanRepository.RemoveEntity(id);
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
        public IActionResult Update(string id, PlanModel Planmodel)
        {
            var isGoodRequest = long.TryParse(id, out long idOut);

            if (!isGoodRequest)
            {
                return BadRequest("Invalid ID format.");
            }

            Planmodel.PlanId = idOut;
            var isSuccess = _domain.PlanRepository.UpdateEntity(Planmodel);

            var statusCode = isSuccess
                ? StatusCodes.Status204NoContent
                : StatusCodes.Status400BadRequest;

            return new StatusCodeResult(statusCode);
        }
    }
}
