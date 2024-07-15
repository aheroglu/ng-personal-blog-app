using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalBlogServer.Application.Features.Abouts.GetAll;
using PersonalBlogServer.Application.Features.Abouts.Update;
using PersonalBlogServer.WebAPI.Abstractions;

namespace PersonalBlogServer.WebAPI.Controllers
{
    public class AboutsController : ApiController
    {
        public AboutsController(IMediator mediator) : base(mediator)
        {
        }


        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var values = await mediator.Send(new GetAllAboutQuery(), cancellationToken);
            return StatusCode(200, values);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateAboutCommand request, CancellationToken cancellationToken)
        {
            await mediator.Send(request, cancellationToken);
            return StatusCode(200, new { Message = "About updated successfully" });
        }
    }
}
