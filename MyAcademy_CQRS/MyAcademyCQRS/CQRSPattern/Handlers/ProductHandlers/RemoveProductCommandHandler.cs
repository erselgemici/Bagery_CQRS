using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.ProductCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers
{
    public class RemoveProductCommandHandler
    {
        private readonly IUnitOfWork _uow;

        public RemoveProductCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Handle(RemoveProductCommand command)
        {
            var repository = _uow.GetRepository<Product>();
            var value = await repository.GetByIdAsync(command.Id);
            if (value != null)
            {
                repository.Delete(value);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
