using Domain.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetUniversityList([FromBody] GetUniversityQuery query)
        {
            var res = await this._mediator.Send(query);
            return this.StatusCode((int)res.Status, res);
        }
    }
}
