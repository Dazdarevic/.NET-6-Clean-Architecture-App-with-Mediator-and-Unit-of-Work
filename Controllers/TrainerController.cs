using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Napredne_baze_podataka_API.DTOs;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Mediator_Pattern.Commands.Trainer_Commands;
using Napredne_baze_podataka_API.Mediator_Pattern.Queries.Trainer;
using Napredne_baze_podataka_API.Models;
using System.Collections.Generic;

namespace Napredne_baze_podataka_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly IMediator mediator;

        public TrainerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("members")]
        [Authorize]
        public async Task<IActionResult> GetAllMembersAsync()
        {
            var command = new GetAllMembersQuery();
            var membersDto = await mediator.Send(command);
            return Ok(membersDto);
        }

        [HttpPost("add-comment")]
        [Authorize]
        public async Task<IActionResult> AddComment([FromBody] Comment comment)
        {
            var command = new AddCommentCommand(comment);
            var isAdded = await mediator.Send(command);

            if (isAdded)
            {
                return Ok("Comment added successfully.");
            }

            return BadRequest("Adding comment failed. Member or trainer not found.");
        }

        [HttpPatch("update-comment-text/{commentId}")]
        [Authorize]
        public async Task<IActionResult> UpdateCommentText(int commentId, string comment)
        {
            var command = new UpdateCommentTextCommand(commentId, comment);
            var isUpdated = await mediator.Send(command);

            if (isUpdated)
            {
                return Ok("Comment text updated successfully.");
            }

            return NotFound("Comment not found.");
        }

    }
}
