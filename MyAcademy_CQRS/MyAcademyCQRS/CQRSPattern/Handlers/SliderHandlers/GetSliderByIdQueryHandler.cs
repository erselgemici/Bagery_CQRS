using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Queries.SliderQueries;
using MyAcademyCQRS.CQRSPattern.Results.SliderResults;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.SliderHandlers
{
    public class GetSliderByIdQueryHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetSliderByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<GetSliderByIdQueryResult> Handle(GetSliderByIdQuery query)
        {
            var value = await _uow.GetRepository<Slider>().GetByIdAsync(query.Id);
            return _mapper.Map<GetSliderByIdQueryResult>(value);
        }
    }
}
