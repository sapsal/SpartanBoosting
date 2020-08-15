﻿using SpartanBoosting.Data;
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

		public void Delete(PurchaseForm purchaseForm)
		{
			context.PurchaseForm.Remove(purchaseForm);
		}

		public IEnumerable<PurchaseForm> GetAllPurchaseOrder()
		{
			return context.PurchaseForm;
		}

		public PurchaseForm GetPurchaseForm(int Id)
		{
			return context.PurchaseForm.FirstOrDefault(item => item.Id == Id);
		}

		public PurchaseForm Update(PurchaseForm purchaseFormChanges)
		{
			var entity = context.PurchaseForm.FirstOrDefault(item => item.Id == purchaseFormChanges.Id);

			// Validate entity is not null
			if (entity != null)
			{
				entity = purchaseFormChanges;

				// Save changes in database
				context.SaveChanges();
			}
			return purchaseFormChanges;
		}
	}
}
