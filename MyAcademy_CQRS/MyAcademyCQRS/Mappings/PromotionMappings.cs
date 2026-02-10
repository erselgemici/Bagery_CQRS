using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.PromotionCommands;
using MyAcademyCQRS.CQRSPattern.Queries.PromotionQueries;
using MyAcademyCQRS.CQRSPattern.Results.PromotionResults;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Mappings
{
    public class PromotionMappings : Profile
    {
        public PromotionMappings()
        {
            CreateMap<Promotion, GetPromotionQueryResult>().ReverseMap();
            CreateMap<Promotion, GetPromotionByIdQueryResult>().ReverseMap();
            CreateMap<Promotion, CreatePromotionCommand>().ReverseMap();
            CreateMap<Promotion, UpdatePromotionCommand>().ReverseMap();
            CreateMap<Promotion, GetPromotionByIdQuery>().ReverseMap();
        }
    }
}
