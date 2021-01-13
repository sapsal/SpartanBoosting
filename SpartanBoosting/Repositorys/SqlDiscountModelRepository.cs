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
			return context.Discount.ToList();
		}
		public void Delete(DiscountModel discountModel) {
			context.Discount.Remove(discountModel);
			context.SaveChanges();
		}
	}
}
