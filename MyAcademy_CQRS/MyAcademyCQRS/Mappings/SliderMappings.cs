using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.SliderCommands;
using MyAcademyCQRS.CQRSPattern.Queries.SliderQueries;
using MyAcademyCQRS.CQRSPattern.Results.SliderResults;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Mappings
{
    public class SliderMappings : Profile
    {
        public SliderMappings()
        {
            CreateMap<Slider, GetSliderQueryResult>().ReverseMap();
            CreateMap<Slider, GetSliderByIdQueryResult>().ReverseMap();
            CreateMap<Slider, CreateSliderCommand>().ReverseMap();
            CreateMap<Slider, UpdateSliderCommand>().ReverseMap();
            CreateMap<Slider, GetSliderByIdQuery>().ReverseMap();
        }
    }
}
