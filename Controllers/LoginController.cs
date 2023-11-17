using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Napredne_baze_podataka_API.DTOs;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Mediator_Pattern.Commands.Login_Commands;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator mediator;

        public LoginController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost]
        [Route("PostLoginDetails")]
        public async Task<IActionResult> PostLoginDetails(UserData userData)
        {
            var command = new PostLoginDetailsCommand(userData);
            var result = await mediator.Send(command);

            if (result == null)
            {
                return BadRequest();
            }

            var jsonResult = new JsonResult(result);

            return Ok(jsonResult);
        }

    }
}
