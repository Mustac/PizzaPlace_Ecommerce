using AutoMapper;

namespace PizzaPlace.BlazorServer.Helpers.Mapper
{
    public class Map : Profile
    {
        public Map()
        {
            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<ProductDTO, ProductInputDTO>().ReverseMap();
            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<ApplicationUser, UserDTO>().ReverseMap();
        }
    }
}
