using SpartanBoosting.Models.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Models.Repositorys
{
	public interface IPurchaseOrderRepository
	{
		PurchaseForm GetPurchaseForm(int Id);
		PurchaseForm GetPurchaseFormWithBooster(int Id);
		IEnumerable<PurchaseForm> GetBasicPurchaseOrder();
		PurchaseForm GetPurchaseFormModelsIncludedById(int Id);
		PurchaseForm GetPurchaseFormModelsIncludedByIdAndUser(int Id, ApplicationUser applicationUser);
		IEnumerable<PurchaseForm> GetAllPurchaseOrder();
		IEnumerable<PurchaseForm> GetAllPurchaseOrderWithBooster();
		IEnumerable<PurchaseForm> GetAllUnCompletedPurchaseOrderWithBooster();
		IEnumerable<PurchaseForm> GetAllPurchaseOrderAvailable();
		PurchaseForm Add(PurchaseForm purchaseForm);
		PurchaseForm Update(PurchaseForm purchaseFormChanges);
		IEnumerable<PurchaseForm> GetAllPurchaseOrdersByUser(ApplicationUser applicationUser);
		void Delete(PurchaseForm purchaseForm);
	}
}
