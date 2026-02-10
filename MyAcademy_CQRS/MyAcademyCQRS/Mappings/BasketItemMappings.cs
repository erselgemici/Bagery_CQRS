using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.BasketCommands;
using MyAcademyCQRS.CQRSPattern.Results.BasketResults;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Mappings
{
    public class BasketItemMappings : Profile
    {
        public BasketItemMappings()
        {
            CreateMap<CreateBasketItemCommand, BasketItem>().ReverseMap();

            CreateMap<BasketItem, GetBasketQueryResult>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(dest => dest.ProductImage, opt => opt.MapFrom(src => src.Product.ImageUrl));
        }
    }
}
