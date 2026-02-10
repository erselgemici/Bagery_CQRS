using MyAcademyCQRS.CQRSPattern.Commands.PhotoGalleryCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.PhotoGalleryHandlers
{
    public class RemovePhotoGalleryCommandHandler
    {
        private readonly IUnitOfWork _uow;

        public RemovePhotoGalleryCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Handle(RemovePhotoGalleryCommand command)
        {
            var repo = _uow.GetRepository<PhotoGallery>();
            var value = await repo.GetByIdAsync(command.Id);

            if (value != null)
            {
                repo.Delete(value);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
