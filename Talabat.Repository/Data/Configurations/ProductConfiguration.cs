using Talabat.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Repository.Data.Configurations
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasOne(P => P.Category)
				   .WithMany()
				   .HasForeignKey(P => P.CategoryId);

			builder.HasOne(P => P.Brand)
				   .WithMany()
				   .HasForeignKey(P => P.BrandId);
		}
	}
}
