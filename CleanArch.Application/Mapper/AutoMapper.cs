using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Products.Commands;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            // Product
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NameCategory, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.NameCategory, opt => opt.MapFrom(src => src.Category.Name))
                .ReverseMap();

            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();


            // Category
            CreateMap<Category, CategoryDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();
        }
    }
}
