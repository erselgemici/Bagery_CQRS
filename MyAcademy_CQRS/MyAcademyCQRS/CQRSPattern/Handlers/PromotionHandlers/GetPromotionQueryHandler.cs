using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Results.PromotionResults;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.PromotionHandlers
{
    public class GetPromotionQueryHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetPromotionQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<GetPromotionQueryResult>> Handle()
        {
            var values = await _uow.GetRepository<Promotion>().GetAllAsync();
            return _mapper.Map<List<GetPromotionQueryResult>>(values);
        }
    }
}
