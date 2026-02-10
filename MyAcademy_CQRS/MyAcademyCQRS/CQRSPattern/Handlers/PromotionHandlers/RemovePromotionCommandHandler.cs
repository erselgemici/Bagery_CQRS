using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.PromotionCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.DataAccess.Concrete; 
using MyAcademyCQRS.DesignPatterns.Observer; 
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.PromotionHandlers
{
    public class RemovePromotionCommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly AppDbContext _context; 

        public RemovePromotionCommandHandler(IUnitOfWork uow, AppDbContext context)
        {
            _uow = uow;
            _context = context;
        }

        public async Task Handle(RemovePromotionCommand command)
        {
            var repo = _uow.GetRepository<Promotion>();
            var value = await repo.GetByIdAsync(command.Id);

            if (value != null)
            {
                string title = value.Title;

                string backupDetail = $"Silinen Fiyat: {value.Price}₺ | Silinen Açıklama: {value.Description}";

                repo.Delete(value);
                await _uow.SaveChangesAsync();

                ObserverObject observerObject = new ObserverObject();
                observerObject.RegisterObserver(new DbLoggerObserver(_context));

                observerObject.NotifyObservers(
                    $"Kampanya silindi: {title} (ID: {command.Id})",
                    "Promotion",
                    backupDetail
                );
            }
        }
    }
}
