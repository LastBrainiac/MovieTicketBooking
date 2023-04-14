using AutoMapper;
using MTBS.BasketAPI.DTOs;
using MTBS.BasketAPI.Models;

namespace MTBS.BasketAPI
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<CustomerBasket, CustomerBasketDTO>().ReverseMap();
        }
    }
}
