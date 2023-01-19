
using BLL.Services;
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
        public async Task<ActionResult<List<SchoolDTO>>> GetAll()
        {
            var dtos = await _mediator.Send(new GetSchoolQuery());
            return Ok(dtos);
          
        }
        [HttpGet("GetSchool", Name = "Get_")]
        public async Task<ActionResult<SchoolDTO>> Get( int id)
        {
            var Add = new GetSchoolByIdQuery() { Id = id };
            var dtos = await _mediator.Send(Add);
            return Ok(dtos);

        }
        [HttpPost("AddSchool", Name = "Add")]
        public async Task<ActionResult<List<SchoolDTO>>> Add([FromBody] CreateSchoolCommand Add)
        { 
            var dtos = await _mediator.Send( Add );
            return Ok(dtos);

        }
        [HttpPost("updateSchool", Name = "update")]
        public async Task<ActionResult<SchoolDTO>> update([FromBody] UpdateSchoolCommand Update)
        {
            var dtos = await _mediator.Send(Update);
            return Ok(dtos);

        }
        [HttpDelete("delete", Name = "delete")]
        public async Task<ActionResult<SchoolDTO>> delete(int id)
        {
            var Add = new DeleteSchoolCommand() { Id = id };
            var dtos = await _mediator.Send(Add);
            return Ok(dtos);

        }
    }
}
