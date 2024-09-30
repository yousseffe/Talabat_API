﻿using Talabat.Core.Entities;
using Talabat.Core.Interfaces;
using Talabat.Repository.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Repository.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		private readonly StoreContext _dbcontext;

		public GenericRepository(StoreContext dbcontext)
        {
			_dbcontext = dbcontext;
		}
        public async Task<IEnumerable<T>> GetAllAsync()
		{
			if(typeof(T) == typeof(Product))
			{
				return (IEnumerable<T>) await _dbcontext.Products.Include(P => P.Category).Include(P => P.Brand).AsNoTracking().ToListAsync();
			}
			return await _dbcontext.Set<T>().AsNoTracking().ToListAsync();
		}

		public async Task<T?> GetAsync(int id)
		{
			if(typeof(T) == typeof(Product))
			{
				return await _dbcontext.Products.Where(P => P.Id == id).Include(P => P.Category).Include(P => P.Brand).FirstOrDefaultAsync() as T;
			}
			return await _dbcontext.Set<T>().FindAsync(id);
		}
	}
}
