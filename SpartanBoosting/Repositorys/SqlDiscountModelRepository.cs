using Microsoft.EntityFrameworkCore;
using SpartanBoosting.Data;
using SpartanBoosting.Models;
using SpartanBoosting.Models.Pricing;
using SpartanBoosting.Repositorys.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Repositorys
{
	public class SqlDiscountModelRepository : IDiscountModelRepository
	{
		private readonly ApplicationDbContext context;

		public SqlDiscountModelRepository(ApplicationDbContext context)
		{
			this.context = context;
		}
		public List<DiscountModel> GetDiscountModels()
		{
			return context.Discount.AsNoTracking().Where(x => x.InUse).ToList();
		}
		public DiscountModel Update(DiscountModel discountModel)
		{
			var entity = context.Discount.FirstOrDefault(item => item.Id == discountModel.Id);

			// Validate entity is not null
			if (entity != null)
			{
				entity = discountModel;

				// Save changes in database
				context.SaveChanges();
			}
			return discountModel;
		}

		public DiscountModel SetNotInUse(DiscountModel discountModel)
		{
			var entity = context.Discount.FirstOrDefault(item => item.Id == discountModel.Id);

			// Validate entity is not null
			if (entity != null)
			{
				discountModel.InUse = false;
				entity = discountModel;

				// Save changes in database
				context.SaveChanges();
			}
			return discountModel;
		}
		public void Delete(DiscountModel discountModel) {
			context.Discount.Remove(discountModel);
			context.SaveChanges();
		}
	}
}
