using Domain.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Webservice.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IMediator _mediatr;
        public AuthController(IMediator mediatr)
        {
            this._mediatr = mediatr;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterCommand command)
        {
            var res = await _mediatr.Send(command);
            if (res.IsSuccess == false)
            {
                return BadRequest(res);
            }
            return this.Ok(res);
        }
    }
}
