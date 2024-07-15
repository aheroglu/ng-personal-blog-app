using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalBlogServer.Application.Features.Messages.Create;
using PersonalBlogServer.Application.Features.Messages.Delete;
using PersonalBlogServer.Application.Features.Messages.GetAll;
using PersonalBlogServer.Application.Features.Messages.GetById;
using PersonalBlogServer.WebAPI.Abstractions;

namespace PersonalBlogServer.WebAPI.Controllers
{
    public class MessagesController : ApiController
    {
        public MessagesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var values = await mediator.Send(new GetAllMessagesQuery(), cancellationToken);
            return StatusCode(200, values);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var values = await mediator.Send(new GetMessageByIdQuery(id), cancellationToken);
            return StatusCode(200, values);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            await mediator.Send(request, cancellationToken);
            return StatusCode(200, new { Message = "Message created successfully" });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await mediator.Send(new DeleteMessageCommand(id), cancellationToken);
            return StatusCode(200, new { Message = "Message deleted successfully" });
        }
    }
}
