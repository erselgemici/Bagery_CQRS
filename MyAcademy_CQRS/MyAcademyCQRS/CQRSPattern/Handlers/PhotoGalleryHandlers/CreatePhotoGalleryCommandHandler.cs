using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.PhotoGalleryCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using MyAcademyCQRS.Services; 
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.PhotoGalleryHandlers
{
    public class CreatePhotoGalleryCommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        private readonly CloudStorageService _cloudStorageService;

        public CreatePhotoGalleryCommandHandler(IUnitOfWork uow, IMapper mapper, CloudStorageService cloudStorageService)
        {
            _uow = uow;
            _mapper = mapper;
            _cloudStorageService = cloudStorageService;
        }

        public async Task Handle(CreatePhotoGalleryCommand command)
        {
            // Önce Resim var mı diye bakıp Cloud'a yüklüyoruz
            if (command.Photo != null && command.Photo.Length > 0)
            {
                // Resmi yükle ve gelen Linki (https://...) al
                string uploadedUrl = await _cloudStorageService.UploadFileAsync(command.Photo);

                // Bu linki Command içindeki ImageUrl'e ata
                command.ImageUrl = uploadedUrl;
            }

            var photo = _mapper.Map<PhotoGallery>(command);

         
            await _uow.GetRepository<PhotoGallery>().CreateAsync(photo);
            await _uow.SaveChangesAsync();
        }
    }
}
