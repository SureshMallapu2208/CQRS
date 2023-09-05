using CQRS.Features.Requests.Commands;
using CQRS.Features.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> AllRequests()
        {
            return Ok(await _mediator.Send(new GetAllRequestsQuery()));
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateRequestCommand createRequestCommand)
        {
            return Ok(await _mediator.Send(createRequestCommand));
        }

    }
}
