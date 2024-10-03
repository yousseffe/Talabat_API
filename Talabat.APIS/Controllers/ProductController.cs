using Talabat.Core.Entities;
using Talabat.Core.Interfaces;
using Talabat.Repository.Data.Contexts;
using Talabat.Repository.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Talabat.Repository.Specification.ProductSpecification;
using Talabat.APIS.DTOs;

namespace Talabat.APIS.Controllers
{
	public class ProductController : BaseApiController
	{
		private readonly IGenericRepository<Product> _repository;
		private readonly IMapper _mapper;

		public ProductController(IGenericRepository<Product> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Product>> GetProductById(int id)
		{
			var product = await _repository.GetByIdAsync(id, new ProductSpecification());
			if (product == null)
			{
				return NotFound();
			}
			var MappedProducts = _mapper.Map<Product, ProductDTO>(product);
			return Ok(product);
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
		{
			var products = await _repository.GetAllAsync(new ProductSpecification());
			var MappedProducts = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
			return Ok(products);
		}
	}
}
