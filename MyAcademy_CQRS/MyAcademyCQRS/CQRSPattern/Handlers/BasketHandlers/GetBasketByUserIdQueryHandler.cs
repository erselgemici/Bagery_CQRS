using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.BasketQueries;
using MyAcademyCQRS.CQRSPattern.Results.BasketResults;
using System.Collections.Generic;
using System.Linq;

namespace MyAcademyCQRS.CQRSPattern.Handlers.BasketHandlers
{
    public class GetBasketByUserIdQueryHandler
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetBasketByUserIdQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetBasketQueryResult> Handle(GetBasketByUserIdQuery query)
        {
            // Kullanıcının sepetini bul
            var basket = _context.Baskets.Include(x => x.BasketItems).ThenInclude(y => y.Product)
                                         .FirstOrDefault(x => x.UserId == query.UserId);

            if (basket == null) return new List<GetBasketQueryResult>();

            var values = _mapper.Map<List<GetBasketQueryResult>>(basket.BasketItems);

            return values;
        }
    }
}
