using MyAcademyCQRS.CQRSPattern.Commands.NewsCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.NewsHandlers
{
    public class RemoveNewsCommandHandler
    {
        private readonly IUnitOfWork _uow;

        public RemoveNewsCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Handle(RemoveNewsCommand command)
        {
            var repo = _uow.GetRepository<News>();
            var value = await repo.GetByIdAsync(command.Id);

            if (value != null)
            {
                repo.Delete(value);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
