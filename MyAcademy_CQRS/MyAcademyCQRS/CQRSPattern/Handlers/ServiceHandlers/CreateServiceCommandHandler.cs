using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.ServiceCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ServiceHandlers
{
    public class CreateServiceCommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreateServiceCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task Handle(CreateServiceCommand command)
        {
            var service = _mapper.Map<Service>(command);
            await _uow.GetRepository<Service>().CreateAsync(service);
            await _uow.SaveChangesAsync();
        }
    }
}
