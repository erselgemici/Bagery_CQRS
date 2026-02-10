using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.NewsCommands;
using MyAcademyCQRS.CQRSPattern.Queries.NewsQueries;
using MyAcademyCQRS.CQRSPattern.Results.NewsResults;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Mappings
{
    public class NewsMappings : Profile
    {
        public NewsMappings()
        {
            CreateMap<News, GetNewsQueryResult>().ReverseMap();
            CreateMap<News, GetNewsByIdQueryResult>().ReverseMap();
            CreateMap<News, CreateNewsCommand>().ReverseMap();
            CreateMap<News, UpdateNewsCommand>().ReverseMap();
            CreateMap<News, GetNewsByIdQuery>().ReverseMap();
        }
    }
}
