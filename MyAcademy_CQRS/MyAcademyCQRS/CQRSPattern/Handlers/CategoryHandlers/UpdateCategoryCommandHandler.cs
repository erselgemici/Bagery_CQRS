using MyAcademyCQRS.CQRSPattern.Commands.CategoryCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly IUnitOfWork _uow;

        public UpdateCategoryCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Handle(UpdateCategoryCommand command)
        {
            var repository = _uow.GetRepository<Category>();
            var value = await repository.GetByIdAsync(command.CategoryId);

            if (value != null)
            {
                value.CategoryName = command.CategoryName;
                repository.Update(value);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
