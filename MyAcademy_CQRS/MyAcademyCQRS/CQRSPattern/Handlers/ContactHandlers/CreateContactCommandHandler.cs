using AutoMapper;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.ContactCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.DataAccess.Concrete; 
using MyAcademyCQRS.DesignPatterns.Observer; 
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler
    {
        private readonly IUnitOfWork _uow; 
        private readonly IMapper _mapper;  
        private readonly AppDbContext _context; 

        public CreateContactCommandHandler(IUnitOfWork uow, IMapper mapper, AppDbContext context)
        {
            _uow = uow;
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(CreateContactCommand command)
        {
            var contact = _mapper.Map<Contact>(command);

            await _uow.GetRepository<Contact>().CreateAsync(contact);
            await _uow.SaveChangesAsync();


            ObserverObject observerObject = new ObserverObject();

            observerObject.RegisterObserver(new DbLoggerObserver(_context));

            observerObject.NotifyObservers(
                $"Yeni mesaj alındı: {command.Subject} - {command.Name}",
                "Contact",
                command.Message
            );
        }
    }
}
