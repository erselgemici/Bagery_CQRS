using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.FeatureCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.FeatureHandlers
{
    public class CreateFeatureCommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreateFeatureCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task Handle(CreateFeatureCommand command)
        {
            var feature = _mapper.Map<Feature>(command);
            await _uow.GetRepository<Feature>().CreateAsync(feature);
            await _uow.SaveChangesAsync();
        }
    }
}
