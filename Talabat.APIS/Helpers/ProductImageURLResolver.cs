using AutoMapper;
using Talabat.APIS.DTOs;
using Talabat.Core.Entities;

namespace Talabat.APIS.Helpers
{
	public class ProductImageURLResolver : IValueResolver<Product, ProductDTO, string>
	{
		private readonly IConfiguration configuration;

		public ProductImageURLResolver(IConfiguration configuration)
		{
			this.configuration = configuration;
		}
		public string? Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
		{
			if (source.PictureUrl != null || source.PictureUrl != "")
				return $"{configuration["API_Base_URL"]}/{source.PictureUrl}";
			return null;
		}
	}
}
