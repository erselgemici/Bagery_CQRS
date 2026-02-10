using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.SliderCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.SliderHandlers
{
    public class CreateSliderCommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreateSliderCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task Handle(CreateSliderCommand command)
        {
            var slider = _mapper.Map<Slider>(command);
            await _uow.GetRepository<Slider>().CreateAsync(slider);
            await _uow.SaveChangesAsync();
        }
    }
}
