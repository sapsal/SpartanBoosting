using SpartanBoosting.Models;
using SpartanBoosting.Models.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Repositorys.Interfaces
{
	public interface IDiscountModelRepository
	{
		List<DiscountModel> GetDiscountModels();
		DiscountModel Update(DiscountModel discountModel);
		DiscountModel SetNotInUse(DiscountModel discountModel);
		void Delete(DiscountModel discountModel);
	}
}
