using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.BasketCommands;

namespace MyAcademyCQRS.CQRSPattern.Handlers.BasketHandlers
{
    public class IncreaseBasketItemCommandHandler
    {
        private readonly AppDbContext _context;
        public IncreaseBasketItemCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public void Handle(IncreaseBasketItemCommand command)
        {
            var value = _context.BasketItems.Find(command.Id);
            if (value != null)
            {
                value.Quantity++;
                _context.SaveChanges();
            }
        }
    }
}
