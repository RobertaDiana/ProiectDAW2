using AutoMapper;
using Demo.Models;
using Demo.Models.DTOs;
using Demo.Models.DTOs.Producator;

namespace ProiectDAW2.Helpers
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Produse, ProduseDto>();
            CreateMap<Categorie, CategorieDto>();
            CreateMap<CategorieDto, Categorie>();

            CreateMap<Producator, ProducatorAuthRequestDto>();
            CreateMap<ProducatorAuthRequestDto, Producator>();
            CreateMap<ProducatorAuthResponseDto, Producator>();
            CreateMap<Producator, ProducatorAuthResponseDto>();
        }
    }
    
}
