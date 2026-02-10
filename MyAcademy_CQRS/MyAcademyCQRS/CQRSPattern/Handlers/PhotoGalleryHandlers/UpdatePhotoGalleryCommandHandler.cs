using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.PhotoGalleryCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.PhotoGalleryHandlers
{
    public class UpdatePhotoGalleryCommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UpdatePhotoGalleryCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task Handle(UpdatePhotoGalleryCommand command)
        {
            var repo = _uow.GetRepository<PhotoGallery>();
            var value = await repo.GetByIdAsync(command.PhotoGalleryId);

            if (value != null)
            {
                _mapper.Map(command, value);
                repo.Update(value);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
