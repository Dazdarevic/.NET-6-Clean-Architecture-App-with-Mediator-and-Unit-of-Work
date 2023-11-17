using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Napredne_baze_podataka_API.Commands.Admin;
using Napredne_baze_podataka_API.Data;
using Napredne_baze_podataka_API.DTOs;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Models;
using Napredne_baze_podataka_API.Queries;
using Napredne_baze_podataka_API.Queries.Admin;
using Serilog;

namespace Napredne_baze_podataka_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private readonly IMediator mediator;

        public AdministratorController(IMediator mediator)
        {
            this.mediator = mediator;

        }

        [HttpGet("admins")]
        [Authorize]
        public async Task<IActionResult> GetAdminsAsync(int currentAdminId)
        {
            //Log.Information("Admins getall triggered"); local way to impc(currentAdminId);
            //var adminsDto = mapper.Map<IEnumerable<AdminDto>>(admins);lement serilog, we need to implement this globally.
            //this._logger.LogInformation("| Log || Testing");
            //var admins = await uow.AdministratorRepository.GetAdminsAsync

            var command = new GetAllAdminsQuery(currentAdminId);
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("receptionists")]
        [Authorize]
        public async Task<IActionResult> GetReceptionistsAsync()
        {
            var command = new GetAllReceptionistsQuery();
            var result = await mediator.Send(command);
            return Ok(result);
        }
        [HttpGet("managers")]
        [Authorize]
        public async Task<IActionResult> GetManagersAsync()
        {
            var command = new GetAllManagersQuery();
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("admin/{id}")]
        public async Task<IActionResult> GetAdmin(int id)
        {
            var query = new GetAdminQuery(id); 

            var admin = await mediator.Send(query);

            if (admin == null)
            {
                return NotFound();
            }

            return Ok(admin);
        }

        [HttpPost("add-admin")]
        [Authorize]
        public async Task<IActionResult> AddAdmin(Administrator administrator)
        {
            var command = new AddAdminCommand(administrator);
            var newAdmin = await mediator.Send(command);
            return Ok(newAdmin);
        }
        [HttpPost("add-manager")]
        [Authorize]
        public async Task<IActionResult> AddManager(ManagerS manager)
        {
            var command = new AddManagerCommand(manager);
            var newManager = await mediator.Send(command);
            return Ok(newManager);
        }
        [HttpPost("add-receptionist")]
        [Authorize]
        public async Task<IActionResult> AddReceptionist(Receptionist receptionist)
        {
            var command = new AddReceptionistCommand(receptionist);
            var newRec = await mediator.Send(command);
            return Ok(newRec);
        }

        [HttpDelete("delete/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            var command = new DeleteAdminCommand(id);
            await mediator.Send(command);
            return Ok();
        }
    }
}
