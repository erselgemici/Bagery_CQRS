using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Results.LogResults;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Mappings
{
    public class LogMappings : Profile
    {
        public LogMappings()
        {
            CreateMap<Log, GetLogQueryResult>().ReverseMap();
        }
    }
}
