using AutoMapper;
using Demo.Models;
using Demo.Models.DTOs.Categorie;
using Demo.Models.DTOs.Producator;
using Demo.Models.DTOs.Produs;

namespace ProiectDAW2.Helpers
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Produse, ProdusDto>();
            CreateMap<ProdusDto, Produse>();

            CreateMap<Produse, ProdusCuProducatorDto>().ForMember(
                dest => dest.NumeProducator,
                opt => opt.MapFrom(src => src.Producator.NumeProducator)
            ); ;

            CreateMap<Categorie, CategorieDto>();
            CreateMap<CategorieDto, Categorie>();

            CreateMap<Producator, ProducatorDto>();

            CreateMap<Producator, ProducatorAuthRequestDto>();
            CreateMap<ProducatorAuthRequestDto, Producator>();
            CreateMap<ProducatorAuthResponseDto, Producator>();
            CreateMap<Producator, ProducatorAuthResponseDto>();
        }
    }
    
}
