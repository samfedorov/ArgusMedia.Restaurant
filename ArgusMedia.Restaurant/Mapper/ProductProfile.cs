using ArgusMedia.Restaurant.Dtos;
using ArgusMedia.Restaurant.Models;
using AutoMapper;

namespace ArgusMedia.Restaurant.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductReadDto>();
        }
    }
}
