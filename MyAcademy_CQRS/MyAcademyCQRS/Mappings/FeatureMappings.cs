using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.FeatureCommands;
using MyAcademyCQRS.CQRSPattern.Queries.FeatureQueries;
using MyAcademyCQRS.CQRSPattern.Results.FeatureResults;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Mappings
{
    public class FeatureMappings : Profile
    {
        public FeatureMappings()
        {
            CreateMap<Feature, GetFeatureQueryResult>().ReverseMap();
            CreateMap<Feature, GetFeatureByIdQueryResult>().ReverseMap();
            CreateMap<Feature, CreateFeatureCommand>().ReverseMap();
            CreateMap<Feature, UpdateFeatureCommand>().ReverseMap();
            CreateMap<Feature, GetFeatureByIdQuery>().ReverseMap();
        }
    }
}
