using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.AboutCommands;
using MyAcademyCQRS.CQRSPattern.Queries.AboutQueries;
using MyAcademyCQRS.CQRSPattern.Results.AboutResults;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Mappings
{
    public class AboutMappings : Profile
    {
        public AboutMappings()
        {
            CreateMap<About, GetAboutQueryResult>().ReverseMap();
            CreateMap<About, GetAboutByIdQueryResult>().ReverseMap();
            CreateMap<About, CreateAboutCommand>().ReverseMap();
            CreateMap<About, UpdateAboutCommand>().ReverseMap();
            CreateMap<About, GetAboutByIdQuery>().ReverseMap();
        }
    }
}
