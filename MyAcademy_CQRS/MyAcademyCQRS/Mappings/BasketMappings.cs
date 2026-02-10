using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.BasketCommands;
using MyAcademyCQRS.CQRSPattern.Queries.BasketQueries;
using MyAcademyCQRS.CQRSPattern.Results.BasketResults;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Mappings
{
    public class BasketMappings : Profile
    {
        public BasketMappings()
        {
            CreateMap<BasketItem, GetBasketQueryResult>()
    .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
    .ForMember(dest => dest.ProductImage, opt => opt.MapFrom(src => src.Product.ImageUrl))
    .ReverseMap();

            CreateMap<BasketItem, CreateBasketCommand>().ReverseMap();
            CreateMap<BasketItem, UpdateBasketCommand>().ReverseMap();
            CreateMap<BasketItem, GetBasketByIdQueryResult>().ReverseMap();
        }
    }
}
