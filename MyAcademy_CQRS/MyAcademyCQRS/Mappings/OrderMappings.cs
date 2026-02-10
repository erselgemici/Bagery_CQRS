using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.OrderCommands;
using MyAcademyCQRS.CQRSPattern.Results.OrderResults;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Mappings
{
    public class OrderMappings : Profile
    {
        public OrderMappings()
        {
            CreateMap<Order, GetOrderQueryResult>().ReverseMap();
            CreateMap<Order, CreateOrderCommand>().ReverseMap();
            CreateMap<Order, RemoveOrderCommand>().ReverseMap();
        }
    }
}
