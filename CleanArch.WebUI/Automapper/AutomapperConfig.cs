using AutoMapper;
using CleanArch.Domain.Entities;
using CleanArch.WebUI.Models;

namespace CleanArch.WebUI.Automapper
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Product, ProductResponseModel>()
                .ForMember(dest => dest.NameCategory, opt => opt.MapFrom(src => src.Name));

            CreateMap<Category, CategoryResponseModel>()
                .ForMember(dest => dest.ProductsQuantity, opt => opt.MapFrom(src => src.Products.Count()));
        }
    }
}
