using Domain.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            return this.StatusCode((int)res.Status, res);
        }
    }
}
