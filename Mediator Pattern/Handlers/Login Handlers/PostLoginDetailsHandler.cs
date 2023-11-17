using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Napredne_baze_podataka_API.DTOs;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Mediator_Pattern.Commands.Login_Commands;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Handlers.Login_Handlers
{
    public class PostLoginDetailsHandler : IRequestHandler<PostLoginDetailsCommand, JsonResult>
    {
        private readonly IUnitOfWork uow;

        public PostLoginDetailsHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<JsonResult> Handle(PostLoginDetailsCommand request, CancellationToken cancellationToken)
        {
            var loginResult = await uow.LoginRepository.PostLoginDetails(request.UserData);
            return (JsonResult)loginResult;
        }
    }

}
