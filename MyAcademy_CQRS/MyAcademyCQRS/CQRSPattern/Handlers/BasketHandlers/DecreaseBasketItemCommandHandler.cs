using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.BasketCommands;

namespace MyAcademyCQRS.CQRSPattern.Handlers.BasketHandlers
{
    public class DecreaseBasketItemCommandHandler
    {
        private readonly AppDbContext _context;
        public DecreaseBasketItemCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public void Handle(DecreaseBasketItemCommand command)
        {
            var value = _context.BasketItems.Find(command.Id);
            if (value != null)
            {
                if (value.Quantity > 1)
                {
                    value.Quantity--; 
                }
                else
                {
                    _context.BasketItems.Remove(value);
                }
                _context.SaveChanges();
            }
        }
    }
}
