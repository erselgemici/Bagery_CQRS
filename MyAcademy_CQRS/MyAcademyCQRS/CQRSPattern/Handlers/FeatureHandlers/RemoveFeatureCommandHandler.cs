using MyAcademyCQRS.CQRSPattern.Commands.FeatureCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.FeatureHandlers
{
    public class RemoveFeatureCommandHandler
    {
        private readonly IUnitOfWork _uow;

        public RemoveFeatureCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Handle(RemoveFeatureCommand command)
        {
            var repo = _uow.GetRepository<Feature>();
            var value = await repo.GetByIdAsync(command.Id);

            if (value != null)
            {
                repo.Delete(value);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
