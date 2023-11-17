using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Mediator_Pattern.Commands.Sponsor_Commands;
using Napredne_baze_podataka_API.Mediator_Pattern.Queries.Sponsor_Queries;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SponsorController : ControllerBase
    {
        private readonly IMediator mediator;

        public SponsorController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("add-ad")]
        //[Authorize]
        public async Task<IActionResult> AddAd(Advertisement ad)
        {
            var command = new AddAdCommand(ad);
            var addedAd = await mediator.Send(command);
            return Ok(addedAd);
        }

        //ovo mogu videti i clanovi
        [HttpGet("list-ads")]
        [Authorize]
        public async Task<IActionResult> ListAds()
        {
            var command = new ListAdsQuery();
            var ads = await mediator.Send(command);
            return Ok(ads);
        }
    }
}
