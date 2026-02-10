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
    public class CreatePromotionCommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context; 

        public CreatePromotionCommandHandler(IUnitOfWork uow, IMapper mapper, AppDbContext context)
        {
            _uow = uow;
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(CreatePromotionCommand command)
        {
            // --- Normal Kayıt İşlemi ---
            var promotion = _mapper.Map<Promotion>(command);
            await _uow.GetRepository<Promotion>().CreateAsync(promotion);
            await _uow.SaveChangesAsync();


            // Yayıncıyı (Subject) oluştur
            ObserverObject observerObject = new ObserverObject();

            // Gözlemciyi (Observer) oluştur ve yayıncıya abone et
            observerObject.RegisterObserver(new DbLoggerObserver(_context));

            // Log atılacak
            observerObject.NotifyObservers(
                $"Yeni kampanya eklendi: {command.Title}",
                "Promotion",
                $"Açıklama: {command.Description} | Fiyat: {command.Price}₺"
            );
        }
    }
}
