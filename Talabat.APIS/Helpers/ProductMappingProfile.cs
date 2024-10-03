using Talabat.APIS.DTOs;
using Talabat.Core.Entities;
using AutoMapper;
namespace Talabat.APIS.Helpers
{
	public class ProductMappingProfile:Profile
	{
		public ProductMappingProfile()
		{
			CreateMap<Product, ProductDTO>()
				.ForMember(p => p.BrandName, o => o.MapFrom(r => r.Brand.Name))
				.ForMember(p => p.BrandName, o => o.MapFrom(r => r.Category.Name))
				.ForMember(p => p.PictureUrl, o => o.MapFrom<ProductImageURLResolver>())
				.ReverseMap();
		}
	}
}
