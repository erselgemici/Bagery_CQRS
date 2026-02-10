using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.ContactCommands;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Mappings
{
    public class ContactMappings : Profile
    {
        public ContactMappings()
        {
            CreateMap<CreateContactCommand, Contact>().ReverseMap();
        }
    }
}
