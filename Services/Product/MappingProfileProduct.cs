using AutoMapper;
using Repositories.Entities;

namespace NLayeredArthitecture.Services
{
    public class MappingProfileProduct : Profile
    {
        public MappingProfileProduct()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<CreateProductRequestDto, Product>().ForMember(destination => destination.ProductName, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));
            CreateMap<UpdateProductRequestDto, Product>().ForMember(destination => destination.ProductName, opt => opt.MapFrom(src => src.Name.ToLowerInvariant  ()));

        }
    }
    
}