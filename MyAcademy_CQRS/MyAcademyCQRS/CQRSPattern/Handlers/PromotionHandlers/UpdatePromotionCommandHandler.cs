using AutoMapper;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.PromotionCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.DataAccess.Concrete;
using MyAcademyCQRS.DesignPatterns.Observer;
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.PromotionHandlers
{
    public class UpdatePromotionCommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public UpdatePromotionCommandHandler(IUnitOfWork uow, IMapper mapper, AppDbContext context)
        {
            _uow = uow;
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(UpdatePromotionCommand command)
        {
            var repo = _uow.GetRepository<Promotion>();
            var value = await repo.GetByIdAsync(command.PromotionId);

            if (value != null)
            {


                _mapper.Map(command, value);
                repo.Update(value);
                await _uow.SaveChangesAsync();

                ObserverObject observerObject = new ObserverObject();
                observerObject.RegisterObserver(new DbLoggerObserver(_context));

                string updateInfo = $"Yeni Fiyat: {command.Price}₺ | Yeni Açıklama: {command.Description}";

                observerObject.NotifyObservers(
                    $"Kampanya güncellendi: {command.Title}",
                    "Promotion",
                    updateInfo
                );
            }
        }
    }
}
