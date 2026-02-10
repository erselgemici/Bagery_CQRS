using MyAcademyCQRS.CQRSPattern.Commands.ContactInfoCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ContactInfoHandlers
{
    public class RemoveContactInfoCommandHandler
    {
        private readonly IUnitOfWork _uow;

        public RemoveContactInfoCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Handle(RemoveContactInfoCommand command)
        {
            var repo = _uow.GetRepository<ContactInfo>();
            var value = await repo.GetByIdAsync(command.Id);

            if (value != null)
            {
                repo.Delete(value);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
