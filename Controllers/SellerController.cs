using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Mediator_Pattern.Commands.Seller_Commands;
using Napredne_baze_podataka_API.Mediator_Pattern.Queries.Seller_Queries;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly IMediator mediator;

        public SellerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("add-product")]
        //[Authorize]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var command = new AddProductCommand(product);
            var addedProduct = await mediator.Send(command);
            return Ok(addedProduct);
        }

        //ovo mogu videti i clanovi
        [HttpGet("list-products")]
        [Authorize]
        public async Task<IActionResult> ListProducts()
        {
            var command = new ListProductsQuery();
            var products = await mediator.Send(command);
            return Ok(products);
        }
    }
}
