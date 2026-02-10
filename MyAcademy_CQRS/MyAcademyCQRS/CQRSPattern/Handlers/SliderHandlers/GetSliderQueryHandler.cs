using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Results.SliderResults;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.SliderHandlers
{
    public class GetSliderQueryHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetSliderQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<GetSliderQueryResult>> Handle()
        {
            var values = await _uow.GetRepository<Slider>().GetAllAsync();
            return _mapper.Map<List<GetSliderQueryResult>>(values);
        }
    }
}
