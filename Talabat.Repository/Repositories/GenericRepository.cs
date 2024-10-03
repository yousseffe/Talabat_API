using Talabat.Core.Entities;
using Talabat.Core.Interfaces;
using Talabat.Repository.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Specification;
using Talabat.Repository.Specification;

namespace Talabat.Repository.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		private readonly StoreContext _dbcontext;

		public GenericRepository(StoreContext dbcontext)
        {
			_dbcontext = dbcontext;
		}
		public async Task<IEnumerable<T>> GetAllAsync(ISpecification<T> specification)
		{
			return await SpecofocationEvaluator<T>.GetQuery(_dbcontext.Set<T>(), specification).ToListAsync();
		}

		public async Task<T?> GetByIdAsync(int id, ISpecification<T> specification)
		{
			return await SpecofocationEvaluator<T>.GetQuery(_dbcontext.Set<T>(), specification).FirstOrDefaultAsync();
		}
	}
}
