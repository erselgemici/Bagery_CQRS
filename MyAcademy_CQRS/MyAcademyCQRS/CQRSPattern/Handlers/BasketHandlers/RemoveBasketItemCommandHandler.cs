using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.BasketCommands;

namespace MyAcademyCQRS.CQRSPattern.Handlers.BasketHandlers
{
    public class RemoveBasketItemCommandHandler
    {
        private readonly AppDbContext _context;

        public RemoveBasketItemCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public void Handle(RemoveBasketItemCommand command)
        {
            var value = _context.BasketItems.Find(command.Id);
            if (value != null)
            {
                _context.BasketItems.Remove(value);
                _context.SaveChanges();
            }
        }
    }
}
