using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.ContactInfoCommands;
using MyAcademyCQRS.DataAccess.Abstract;
using MyAcademyCQRS.Entities;
using System.Threading.Tasks;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ContactInfoHandlers
{
    public class UpdateContactInfoCommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UpdateContactInfoCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task Handle(UpdateContactInfoCommand command)
        {
            var repo = _uow.GetRepository<ContactInfo>();
            var value = await repo.GetByIdAsync(command.ContactInfoId);

            if (value != null)
            {
                _mapper.Map(command, value);
                repo.Update(value);
                await _uow.SaveChangesAsync();
            }
        }
    }
}
