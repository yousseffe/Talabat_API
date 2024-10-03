using Talabat.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Specification;

namespace Talabat.Core.Interfaces
{
	public interface IGenericRepository<T> where T : BaseEntity
	{
		 Task<IEnumerable<T>> GetAllAsync(ISpecification<T> specification);

		 Task<T?> GetByIdAsync(int id, ISpecification<T> specification);
	}
}
