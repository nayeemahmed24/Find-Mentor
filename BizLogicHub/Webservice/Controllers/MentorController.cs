using Microsoft.AspNetCore.Mvc;
using MediatR;
using Model.Dto.Qureies;
using Domain.Query;

namespace Webservice.Controllers
{
    [Route("api/mentor")]
    [ApiController]
    public class MentorController : Controller
    {
        private readonly IMediator _mediator;
        public MentorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("find")]
        public async Task<IActionResult> GetMentorList([FromBody] GetMentorListQuery query)
        {
            var res = await _mediator.Send(query);
            return this.StatusCode((int)res.Status, res);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetMentorDetails([FromQuery] GetMentorDetailsQuery query)
        {
            var res = await _mediator.Send(query);
            return this.StatusCode((int)res.Status, res);
        }
    }
}
