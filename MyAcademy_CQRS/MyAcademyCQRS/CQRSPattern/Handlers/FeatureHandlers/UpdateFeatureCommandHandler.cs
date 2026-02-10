using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.FeatureCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.FeatureHandlers
{
    public class UpdateFeatureCommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UpdateFeatureCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task Handle(UpdateFeatureCommand command)
        {
            var repo = _uow.GetRepository<Feature>();
            var value = await repo.GetByIdAsync(command.FeatureId);

            if (value != null)
            {
                _mapper.Map(command, value);
                repo.Update(value);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
