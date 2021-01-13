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
		void Delete(DiscountModel discountModel);
	}
}
