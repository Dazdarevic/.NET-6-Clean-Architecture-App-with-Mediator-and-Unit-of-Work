using MediatR;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Commands.Member_Commands
{
    public class RateTrainerCommand : IRequest<bool>
    {
        public int MemberId { get; set; }
        public int TrainerId { get; set; }
        public int RatingValue { get; set; }
    }
}
