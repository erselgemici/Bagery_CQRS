using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.ContactInfoCommands;
using MyAcademyCQRS.CQRSPattern.Queries.ContactInfoQueries;
using MyAcademyCQRS.CQRSPattern.Results.ContactInfoResults;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Mappings
{
    public class ContactInfoMappings : Profile
    {
        public ContactInfoMappings()
        {
            CreateMap<ContactInfo, GetContactInfoQueryResult>().ReverseMap();
            CreateMap<ContactInfo, GetContactInfoByIdQueryResult>().ReverseMap();
            CreateMap<ContactInfo, CreateContactInfoCommand>().ReverseMap();
            CreateMap<ContactInfo, UpdateContactInfoCommand>().ReverseMap();
            CreateMap<ContactInfo, GetContactInfoByIdQuery>().ReverseMap();
        }
    }
}
