using ArgusMedia.Restaurant.Dtos;
using ArgusMedia.Restaurant.Models;
using AutoMapper;

namespace ArgusMedia.Restaurant.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderCreateDto, Order>();
            CreateMap<Order, OrderReadDto>();
        }
    }
}
