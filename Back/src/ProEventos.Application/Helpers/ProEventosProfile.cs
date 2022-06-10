using AutoMapper;
using ProEventos.Application.Dtos;
using ProEventos.Domain;

namespace ProEventos.Application.Helpers
{
    public class ProEventosProfile : Profile
    {
        public ProEventosProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<ProductConfiguration, ProductConfigurationDTO>().ReverseMap();
            CreateMap<ProductFilter, ProductFilterDTO>().ReverseMap();
            CreateMap<ProductFilterItem, ProductFilterItemDTO>().ReverseMap();
            CreateMap<ProductGrade, ProductGradeDTO>().ReverseMap();
            CreateMap<ProductGroup, ProductGroupDTO>().ReverseMap();
            CreateMap<ProductSubGroup, ProductSubGroupDTO>().ReverseMap();
        }
    }
}