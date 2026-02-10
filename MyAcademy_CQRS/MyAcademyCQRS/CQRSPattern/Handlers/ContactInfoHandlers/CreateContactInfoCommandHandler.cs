using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.ContactInfoCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ContactInfoHandlers
{
    public class CreateContactInfoCommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CreateContactInfoCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task Handle(CreateContactInfoCommand command)
        {
            var contactInfo = _mapper.Map<ContactInfo>(command);
            await _uow.GetRepository<ContactInfo>().CreateAsync(contactInfo);
            await _uow.SaveChangesAsync();
        }
    }
}
