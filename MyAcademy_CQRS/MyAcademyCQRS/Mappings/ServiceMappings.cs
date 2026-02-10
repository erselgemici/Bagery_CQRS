using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.ServiceCommands;
using MyAcademyCQRS.CQRSPattern.Queries.ServiceQueries;
using MyAcademyCQRS.CQRSPattern.Results.ServiceResults;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Mappings
{
    public class ServiceMappings : Profile
    {
        public ServiceMappings()
        {
            CreateMap<Service, GetServiceQueryResult>().ReverseMap();
            CreateMap<Service, GetServiceByIdQueryResult>().ReverseMap();
            CreateMap<Service, CreateServiceCommand>().ReverseMap();
            CreateMap<Service, UpdateServiceCommand>().ReverseMap();
            CreateMap<Service, GetServiceByIdQuery>().ReverseMap();
        }
    }
}
