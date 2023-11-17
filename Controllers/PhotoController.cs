using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Mediator_Pattern.Commands.Photo_Commands;

namespace Napredne_baze_podataka_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IMediator mediator;
        public PhotoController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost("upload-photo")]
        //[Authorize]
        public async Task<IActionResult> UploadPhoto(IFormFile file)
        {
            var command = new AddPhotoCommand { File = file };

            try
            {
                var photoUrl = await mediator.Send(command);
                return Ok(photoUrl);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
