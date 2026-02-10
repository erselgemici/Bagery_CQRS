using MyAcademyCQRS.CQRSPattern.Commands.CategoryCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly IUnitOfWork _uow;

        public RemoveCategoryCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Handle(RemoveCategoryCommand command)
        {
            var repository = _uow.GetRepository<Category>();
            var value = await repository.GetByIdAsync(command.Id);

            if (value != null)
            {
                repository.Delete(value);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
