using MyAcademyCQRS.CQRSPattern.Commands.BasketCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.BasketHandlers
{
    public class RemoveBasketCommandHandler
    {
        private readonly IUnitOfWork _uow;

        public RemoveBasketCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Handle(RemoveBasketCommand command)
        {
            var repo = _uow.GetRepository<BasketItem>();
            var value = await repo.GetByIdAsync(command.Id);

            if (value != null)
            {
                repo.Delete(value);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
