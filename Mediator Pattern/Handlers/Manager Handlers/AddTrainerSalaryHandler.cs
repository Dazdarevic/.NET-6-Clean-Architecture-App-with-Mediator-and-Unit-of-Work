using MediatR;
using Napredne_baze_podataka_API.Commands.Manager_Commands;
using Napredne_baze_podataka_API.Interfaces;

namespace Napredne_baze_podataka_API.Handlers.Trainers
{
    public class AddTrainerSalaryHandler : IRequestHandler<AddTrainerSalaryCommand>
    {
        private readonly IUnitOfWork uow;

        public AddTrainerSalaryHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task Handle(AddTrainerSalaryCommand request, CancellationToken cancellationToken)
        {
            await uow.ManagerRepository.AddTrainerSalaryAsync(request.TrainerId, request.SalaryAmount);
            await uow.SaveAsync();
        }
    }
}
