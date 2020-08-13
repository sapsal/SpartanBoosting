using SpartanBoosting.Data;
using SpartanBoosting.Models.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Models.Repositorys
{
	public class SqlPurchaseOrderRepository: IPurchaseOrderRepository
	{
		private readonly ApplicationDbContext context;

		public SqlPurchaseOrderRepository(ApplicationDbContext context)
		{
			this.context = context;
		}

		public PurchaseForm Add(PurchaseForm purchaseForm)
		{
			context.PurchaseForm.Add(purchaseForm);
			context.SaveChanges();
			return purchaseForm;
		}

		public PurchaseForm Delete(int Id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<PurchaseForm> GetAllEmployee()
		{
			throw new NotImplementedException();
		}

		public PurchaseForm GetPurchaseForm(int Id)
		{
			throw new NotImplementedException();
		}

		public PurchaseForm Update(PurchaseForm purchaseFormChanges)
		{
			throw new NotImplementedException();
		}
	}
}
