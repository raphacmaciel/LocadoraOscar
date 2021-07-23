using AutoMapper;
using LocadoraOscar.API.DTO;
using LocadoraOscar.API.Models;

namespace LocadoraOscar.API.Helpers
{
    public class LocadoraProfile : Profile
    {
        public LocadoraProfile()
        {
            CreateMap<Filme, FilmeDTO>()
                    .ForMember(
                    dest => dest.Genero,
                    opt => opt.MapFrom(src => src.Genero));
            CreateMap<Filme, FilmeRegistroDTO>().ReverseMap();
            CreateMap<Filme, FilmeEdicaoDTO>().ReverseMap();
            CreateMap<Genero, GeneroDTO>().ReverseMap();
        }
    }
}
