using MediatR;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Mediator_Pattern.Commands.Photo_Commands;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Handlers.Photo_Handlers
{
    public class AddPhotoHandler : IRequestHandler<AddPhotoCommand, Photo>
    {
        private readonly IUnitOfWork uow;

        public AddPhotoHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        async Task<Photo> IRequestHandler<AddPhotoCommand, Photo>.Handle(AddPhotoCommand request, CancellationToken cancellationToken)
        {
            var file = request.File;

            if (file == null || file.Length == 0)
                throw new ArgumentException("No file uploaded.");

            if (file.Length > 1024 * 1024) // Ograničenje na veličinu fajla (ovde je 1 MB)
                throw new ArgumentException("File size should not exceed 1 MB.");

            var uploadResult = await uow.PhotoRepository.AddPhotoAsync(file);

            if (uploadResult.Error != null)
                throw new ArgumentException(uploadResult.Error.Message);

            // The photo was successfully uploaded
            var imageUrl = uploadResult.SecureUrl.ToString();
            var publicId = uploadResult.PublicId;

            var photo = new Photo
            {
                Url = imageUrl,
                IsMain = false,
                PublicId = publicId,
            };

            return photo;
        }
    }
}
