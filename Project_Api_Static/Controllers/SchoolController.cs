using BLL.Services.School.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project_Api_Static.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SchoolController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("all", Name = "GetAllSchool")]
        public async Task<ActionResult<List<SchoolDTO>>> Get()
        {
            var dtos = await _mediator.Send(new GetSchoolQuery());
            return Ok(dtos);
          
        }
    }
}
