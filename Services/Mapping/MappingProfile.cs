using AutoMapper;
using Repositories.Entities;

namespace NLayeredArthitecture.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
    
}