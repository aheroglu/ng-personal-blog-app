using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonalBlogServer.Application.Features.Auth.Login;
using PersonalBlogServer.WebAPI.Abstractions;

namespace PersonalBlogServer.WebAPI.Controllers
{
    public class AuthController : ApiController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken)
        {
            var response = await mediator.Send(request, cancellationToken);
            if (response == "User not found!" || response == "Incorrect password!") return BadRequest(new { error = response });
            return Ok(new { token = response });
        }
    }
}
