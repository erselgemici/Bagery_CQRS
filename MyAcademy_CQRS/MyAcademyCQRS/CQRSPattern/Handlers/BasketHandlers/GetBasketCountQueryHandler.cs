using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.BasketQueries;
using System.Linq;

namespace MyAcademyCQRS.CQRSPattern.Handlers.BasketHandlers
{
    public class GetBasketCountQueryHandler
    {
        private readonly AppDbContext _context;

        public GetBasketCountQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public int Handle(GetBasketCountQuery query)
        {
            // Kullanıcının sepetini bul
            var basket = _context.Baskets.Include(x => x.BasketItems)
                                         .FirstOrDefault(x => x.UserId == query.UserId);

            // Sepet yoksa 0 döndür
            if (basket == null) return 0;

            // Varsa içindeki ürünlerin toplam adedini (Quantity) döndür
            return basket.BasketItems.Sum(x => x.Quantity);
        }
    }
}
