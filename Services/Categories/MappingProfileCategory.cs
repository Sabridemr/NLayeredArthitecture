using AutoMapper;
using NLayeredArthitecture.Repositories;

namespace  NLayeredArthitecture.Services
{
    public class MappingProfileCategory : Profile
    {
        public MappingProfileCategory()
        {
            CreateMap<CreateCategoryRequest, Categories>().ReverseMap();
            CreateMap<Categories, ProductCategoryDto>().ReverseMap();
            CreateMap<CreateCategoryRequest,Categories>().ForMember(destination => destination.CategoryName, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));
            CreateMap<CreateCategoryRequest, Categories>().ForMember(destination => destination.CategoryName, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));
        }
        
    }
    
}