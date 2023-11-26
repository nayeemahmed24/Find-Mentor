using Microsoft.AspNetCore.Mvc;
using MediatR;
using Model.Dto.Qureies;
using Domain.Query;
using Microsoft.AspNetCore.Authorization;
using Webservice.Constants;
using Domain.Command;

namespace Webservice.Controllers
{
    [Route("api/mentor")]
    [ApiController]
    [Authorize]
    public class MentorController : Controller
    {
        private readonly IMediator _mediator;
        public MentorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("find")]
        public async Task<IActionResult> GetMentorList([FromBody] GetMentorListQuery query)
        {
            var res = await _mediator.Send(query);
            return this.StatusCode((int)res.Status, res);
        }

        [AllowAnonymous]
        [HttpGet("details")]
        public async Task<IActionResult> GetMentorDetails([FromQuery] GetMentorDetailsQuery query)
        {
            var res = await _mediator.Send(query);
            return this.StatusCode((int)res.Status, res);
        }

        [Authorize(Roles = RoleConstants.Admin)]
        [HttpPost("add-mentor")]
        public async Task<IActionResult> AddMentor([FromBody] AddMentorCommand command)
        {
            var res = await _mediator.Send(command);
            return this.StatusCode((int)res.Status, res);
        }

        [Authorize(Roles = RoleConstants.User)]
        [HttpPost("add-review")]
        public async Task<IActionResult> AddReview([FromBody] AddReviewCommand command)
        {
            string? userId = HttpContext.Items["UserId"]?.ToString();
            command.UserId = userId;
            var res = await _mediator.Send(command);
            return this.StatusCode((int)res.Status, res);
        }
    }
}
