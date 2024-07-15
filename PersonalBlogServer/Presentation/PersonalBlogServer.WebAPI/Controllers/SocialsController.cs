using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalBlogServer.Application.Features.Socials.Create;
using PersonalBlogServer.Application.Features.Socials.Delete;
using PersonalBlogServer.Application.Features.Socials.GetAll;
using PersonalBlogServer.Application.Features.Socials.GetById;
using PersonalBlogServer.Application.Features.Socials.Update;
using PersonalBlogServer.WebAPI.Abstractions;

namespace PersonalBlogServer.WebAPI.Controllers
{
    public class SocialsController : ApiController
    {
        public SocialsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var values = await mediator.Send(new GetAllSocialsQuery(), cancellationToken);
            return StatusCode(200, values);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var values = await mediator.Send(new GetSocialByIdQuery(id), cancellationToken);
            return StatusCode(200, values);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSocialCommand request, CancellationToken cancellationToken)
        {
            await mediator.Send(request, cancellationToken);
            return StatusCode(200, new { Message = "Social created successfully" });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await mediator.Send(new DeleteSocialCommand(id), cancellationToken);
            return StatusCode(200, new { Message = "Social deleted successfully" });
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateSocialCommand request, CancellationToken cancellationToken)
        {
            await mediator.Send(request, cancellationToken);
            return StatusCode(200, new { Message = "Social updated successfully" });
        }
    }
}
