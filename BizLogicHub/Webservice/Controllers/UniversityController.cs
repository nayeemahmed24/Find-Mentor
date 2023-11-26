using Domain.Command;
using Domain.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webservice.Constants;

namespace Webservice.Controllers
{
    [Route("/api/university")]
    [ApiController]
    public class UniversityController : Controller
    {
        private readonly IMediator _mediator;
        public UniversityController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("find")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUniversityList([FromBody] GetUniversityQuery query)
        {
            var res = await this._mediator.Send(query);
            return this.StatusCode((int)res.Status, res);
        }

        [Authorize(Roles = RoleConstants.Admin)]
        [HttpPost("add-university")]
        public async Task<IActionResult> AddUniversity([FromBody] AddUniversityCommand command)
        {
            var res = await _mediator.Send(command);
            return this.StatusCode((int)res.Status, res);
        }
    }
}
