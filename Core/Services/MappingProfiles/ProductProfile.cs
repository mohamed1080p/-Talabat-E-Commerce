using AutoMapper;
using Domain.Entities.ProductModule;
using Shared.Dtos;

namespace Services.MappingProfiles
{
    internal class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductType, TypeResultDto>();
            CreateMap<ProductBrand, BrandResultDto>();
            CreateMap<Product, ProductResultDto>()
                .ForMember(dest => dest.BrandName, options => options.MapFrom(a => a.productBrand.Name))
                .ForMember(dest => dest.TypeName, options => options.MapFrom(a => a.productType.Name))
                .ForMember(dest => dest.PictureUrl, options => options.MapFrom<PictureUrlResolver>());
        }
    }
}
