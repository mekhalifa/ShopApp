using Api.Dtos;
using AutoMapper;
using Core.Entities;

namespace Api.Helpers
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product,ProductToReturnDTO>()
                  .ForMember(d => d.ProductBrand ,m => m.MapFrom(f => f.ProductBrand.Name))
                  .ForMember(d => d.ProductType ,m =>  m.MapFrom(f => f.ProductType.Name))
                  .ForMember(d => d.PictureUrl ,m =>m.MapFrom<ProductUrlResolver>());
        }
    }
}