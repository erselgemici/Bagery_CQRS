using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.SliderCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.SliderHandlers
{
    public class UpdateSliderCommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UpdateSliderCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task Handle(UpdateSliderCommand command)
        {
            var repo = _uow.GetRepository<Slider>();
            var value = await repo.GetByIdAsync(command.SliderId);

            if (value != null)
            {
                _mapper.Map(command, value);
                repo.Update(value);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
