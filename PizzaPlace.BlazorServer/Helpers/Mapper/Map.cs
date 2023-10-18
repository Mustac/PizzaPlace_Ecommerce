using AutoMapper;
using PizzaPlace.BlazorServer.Models.DTOs.Products;

namespace PizzaPlace.BlazorServer.Helpers.Mapper
{
    public class Map : Profile
    {
        public Map()
        {
            CreateMap<ProductDTO, Product>().ReverseMap();
        }
    }
}
