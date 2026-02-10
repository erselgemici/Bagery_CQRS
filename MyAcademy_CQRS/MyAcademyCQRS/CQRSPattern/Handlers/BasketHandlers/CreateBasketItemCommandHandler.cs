using AutoMapper;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.BasketCommands;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.BasketHandlers
{
    public class CreateBasketItemCommandHandler(AppDbContext _context, IMapper _mapper)
    {
        public void Handle(CreateBasketItemCommand command)
        {
            var basket = _context.Baskets.FirstOrDefault(x => x.UserId == command.UserId);

            // Yoksa oluştur
            if (basket == null)
            {
                basket = new Basket
                {
                    UserId = command.UserId
                };
                _context.Baskets.Add(basket);
                _context.SaveChanges();
            }

            // Ürün fiyatını al
            var product = _context.Products.Find(command.ProductId);

            var basketItem = _mapper.Map<BasketItem>(command);

            // Mapper'ın bilmediği (veritabanından gelen) değerleri ekle
            basketItem.BasketId = basket.BasketId;
            basketItem.Price = product.Price;

            _context.BasketItems.Add(basketItem);
            _context.SaveChanges();
        }
    }
}
