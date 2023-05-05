using Bokunda.Preslovitelj.Cqrs.Commands;
using Bokunda.Preslovitelj.Cqrs.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bokunda.Preslovitelj.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TranslationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TranslationController> _logger;

        public TranslationController(IMediator mediator,
            ILogger<TranslationController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("translate")]
        public async Task<TranslateTextResponse> Translate(TranslateTextCommand request)
        {
            var response = await _mediator.Send(request);
            return response;
        }
    }
}