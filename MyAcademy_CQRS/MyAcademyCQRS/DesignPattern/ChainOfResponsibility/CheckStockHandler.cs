using Microsoft.EntityFrameworkCore; 
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.OrderCommands;
using System.Linq;

namespace MyAcademyCQRS.DesignPatterns.ChainOfResponsibility
{
    public class CheckStockHandler : OrderHandlerBase
    {
        private readonly AppDbContext _context;

        public CheckStockHandler(AppDbContext context)
        {
            _context = context;
        }

        public override void Handle(CreateOrderCommand command)
        {
            var basket = _context.Baskets
                                 .Include(x => x.BasketItems)
                                 .FirstOrDefault(x => x.UserId == command.UserId);

            // Eğer sepet null ise VEYA sepetin içi boşsa hata ver
            if (basket == null || basket.BasketItems == null || !basket.BasketItems.Any())
            {
                throw new System.Exception("Sepetiniz boş veya bulunamadı, işlem yapılamıyor.");
            }


            if (_nextHandler != null)
            {
                _nextHandler.Handle(command);
            }
        }
    }
}
