using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Queries.PromotionQueries;
using MyAcademyCQRS.CQRSPattern.Results.PromotionResults;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.PromotionHandlers
{
    public class GetPromotionByIdQueryHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetPromotionByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<GetPromotionByIdQueryResult> Handle(GetPromotionByIdQuery query)
        {
            var value = await _uow.GetRepository<Promotion>().GetByIdAsync(query.Id);
            return _mapper.Map<GetPromotionByIdQueryResult>(value);
        }
    }
}
