using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Results.PhotoGalleryResults;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.PhotoGalleryHandlers
{
    public class GetPhotoGalleryQueryHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetPhotoGalleryQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<GetPhotoGalleryQueryResult>> Handle()
        {
            var values = await _uow.GetRepository<PhotoGallery>().GetAllAsync();
            return _mapper.Map<List<GetPhotoGalleryQueryResult>>(values);
        }
    }
}
