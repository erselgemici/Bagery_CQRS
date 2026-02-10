using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.BasketCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.BasketHandlers
{
    public class UpdateBasketCommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UpdateBasketCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task Handle(UpdateBasketCommand command)
        {
            var repo = _uow.GetRepository<BasketItem>();
            var value = await repo.GetByIdAsync(command.BasketItemId);

            if (value != null)
            {
                _mapper.Map(command, value);
                repo.Update(value);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
