using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Queries.PhotoGalleryQueries;
using MyAcademyCQRS.CQRSPattern.Results.PhotoGalleryResults;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.PhotoGalleryHandlers
{
    public class GetPhotoGalleryByIdQueryHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetPhotoGalleryByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<GetPhotoGalleryByIdQueryResult> Handle(GetPhotoGalleryByIdQuery query)
        {
            var value = await _uow.GetRepository<PhotoGallery>().GetByIdAsync(query.Id);
            return _mapper.Map<GetPhotoGalleryByIdQueryResult>(value);
        }
    }
}
