using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.AboutCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.AboutHandlers
{
    public class CreateAboutCommandHandler 
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreateAboutCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task Handle(CreateAboutCommand command)
        {
            var about = _mapper.Map<About>(command);
            await _uow.GetRepository<About>().CreateAsync(about);
            await _uow.SaveChangesAsync();
        }
    }
}
