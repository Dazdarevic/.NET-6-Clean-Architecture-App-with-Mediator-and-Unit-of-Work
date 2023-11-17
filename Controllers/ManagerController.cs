using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Napredne_baze_podataka_API.Commands.Manager_Commands;
using Napredne_baze_podataka_API.Data;
using Napredne_baze_podataka_API.DTOs;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Models;
using Napredne_baze_podataka_API.Queries.Manager_Queries;
using Sieve.Models;
using Sieve.Services;


namespace Napredne_baze_podataka_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IMediator mediator;

        public ManagerController(IMediator mediator)
        {
            this.mediator = mediator;

        }

        [HttpGet("trainers")]
        //[Authorize]
        public async Task<IActionResult> GetAllTrainersAsync([FromQuery] SieveModel sieveModel)
        {
            var query = new GetAllTrainersQuery(sieveModel);
            var trainers = await mediator.Send(query);

            return Ok(trainers);
        }


        [HttpPost("add-salary")]
        [Authorize]
        public async Task<IActionResult> AddTrainerSalary(int trainerId, string salaryAmount)
        {
            var command = new AddTrainerSalaryCommand(trainerId, salaryAmount);
            await mediator.Send(command);

            return Ok();
        }

        [HttpPost("add-membership")]
        [Authorize]
        public async Task<IActionResult> AddMembership(int memberId, string membershipAmount)
        {
            var command = new AddMembershipCommand(memberId, membershipAmount);
            await mediator.Send(command);

            return Ok();
        }

        [HttpGet("trainer-members/{trainerId}")]
        [Authorize]
        public async Task<IActionResult> GetTrainerOccurrence(int trainerId)
        {
            var query = new GetTrainerOccurrenceQuery(trainerId);
            int occurrenceCount = await mediator.Send(query);

            if (occurrenceCount != 0)
            {
                return Ok(occurrenceCount);
            }

            return BadRequest();
        }


    }
}
