using MediatR;
using Microsoft.AspNetCore.Mvc;
using Napredne_baze_podataka_API.DTOs;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Commands.Login_Commands
{
    public class PostLoginDetailsCommand : IRequest<JsonResult>
    {
        public UserData UserData { get; set; }

        public PostLoginDetailsCommand(UserData userData)
        {
            UserData = userData;
        }
    }
}
