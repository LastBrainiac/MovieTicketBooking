using AutoMapper;
using MTBS.MovieCatalogAPI.Models;
using MTBS.MovieCatalogAPI.Models.Dtos;

namespace MTBS.MovieCatalogAPI.Helpers
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Movie, MovieDto>();            
        }
    }
}
