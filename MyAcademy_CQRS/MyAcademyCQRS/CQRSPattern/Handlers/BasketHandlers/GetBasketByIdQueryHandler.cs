using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Queries.BasketQueries;
using MyAcademyCQRS.CQRSPattern.Results.BasketResults;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.BasketHandlers
{
    public class GetBasketByIdQueryHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetBasketByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<GetBasketByIdQueryResult> Handle(GetBasketByIdQuery query)
        {
            var value = await _uow.GetRepository<BasketItem>().GetByIdAsync(query.Id);
            return _mapper.Map<GetBasketByIdQueryResult>(value);
        }
    }
}
