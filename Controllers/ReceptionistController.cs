using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Napredne_baze_podataka_API.DTOs;
using Napredne_baze_podataka_API.Mediator_Pattern.Commands.Receptionist_Commands;
using Napredne_baze_podataka_API.Mediator_Pattern.Queries.Receptionist_Queries;
using Napredne_baze_podataka_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Napredne_baze_podataka_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptionistController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReceptionistController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmail([FromBody] EmailDto emailModel)
        {
            var command = new SendEmailCommand(emailModel);
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("create-registration-request")]
        public async Task<IActionResult> CreateRegistrationRequest([FromBody] RegistrationRequest request)
        {
            var command = new CreateRegistrationRequestCommand(request);
            var isRequestCreated = await _mediator.Send(command);

            if (isRequestCreated)
            {
                return Ok(new { message = "Registration request created successfully." });
            }

            return BadRequest("Creating registration request failed.");
        }

        [HttpGet("get-all-requests")]
        [Authorize]
        public async Task<IActionResult> GetAllRequests()
        {
            var query = new GetAllRequestsQuery();
            var allRequestsDto = await _mediator.Send(query);
            return Ok(allRequestsDto);
        }

        [HttpPost("approve-registration-request/{requestId}")]
        //[Authorize]
        public async Task<IActionResult> ApproveRegistrationRequest(int requestId)
        {
            var command = new ApproveRegistrationRequestCommand(requestId);
            var isRequestApproved = await _mediator.Send(command);

            if (isRequestApproved)
            {
                return Ok(new { message = "Registration request approved and processed successfully." });
            }

            return BadRequest("Approving registration request failed.");
        }

        [HttpDelete("delete-request/{requestId}")]
        [Authorize]
        public async Task<IActionResult> DeleteRequest(int requestId)
        {
            var command = new DeleteRequestCommand(requestId);
            var isRequestDeleted = await _mediator.Send(command);

            if (isRequestDeleted)
            {
                return Ok(new { message = "Registration request deleted successfully." });
            }

            return NotFound("Registration request not found or deletion failed.");
        }
    }
}
