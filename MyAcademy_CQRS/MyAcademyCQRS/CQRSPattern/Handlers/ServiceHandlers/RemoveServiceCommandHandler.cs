using MyAcademyCQRS.CQRSPattern.Commands.ServiceCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ServiceHandlers
{
    public class RemoveServiceCommandHandler
    {
        private readonly IUnitOfWork _uow;

        public RemoveServiceCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Handle(RemoveServiceCommand command)
        {
            var repo = _uow.GetRepository<Service>();
            var value = await repo.GetByIdAsync(command.Id);

            if (value != null)
            {
                repo.Delete(value);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
