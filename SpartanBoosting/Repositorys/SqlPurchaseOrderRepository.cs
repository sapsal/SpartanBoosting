using Microsoft.EntityFrameworkCore;
using SpartanBoosting.Data;
using SpartanBoosting.Models.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Models.Repositorys
{
	public class SqlPurchaseOrderRepository : IPurchaseOrderRepository
	{
		private readonly ApplicationDbContext context;

		public SqlPurchaseOrderRepository(ApplicationDbContext context)
		{
			this.context = context;
		}

		public PurchaseForm Add(PurchaseForm purchaseForm)
		{
			context.PurchaseForm.Add(purchaseForm);
			purchaseForm.CreatedDate = DateTime.UtcNow;
			if (purchaseForm.Discount != null)
				context.Entry(purchaseForm.Discount).State = EntityState.Unchanged;
			context.SaveChanges();
			return purchaseForm;
		}

		public void Delete(PurchaseForm purchaseForm)
		{
			context.PurchaseForm.Remove(purchaseForm);
			context.SaveChanges();
		}

		public IEnumerable<PurchaseForm> GetAllPurchaseOrder()
		{
			return context.PurchaseForm.Include(p => p.BoostingModel)
			.Include(p => p.CoachingModel)
			.Include(p => p.PlacementMatchesModel)
			.Include(p => p.TFTBoostingModel)
			.Include(p => p.TFTPlacementModel)
			.Include(p => p.WinBoostModel);
		}

		public IEnumerable<PurchaseForm> GetBasicPurchaseOrder()
		{
			return context.PurchaseForm;
		}

		public IEnumerable<PurchaseForm> GetAllPurchaseOrderWithBooster()
		{
			return context.PurchaseForm.Include(p => p.BoostingModel)
			.Include(p => p.CoachingModel)
			.Include(p => p.PlacementMatchesModel)
			.Include(p => p.TFTBoostingModel)
			.Include(p => p.TFTPlacementModel)
			.Include(p => p.WinBoostModel).Include(p => p.BoosterAssignedTo);
		}

		public IEnumerable<PurchaseForm> GetAllUnCompletedPurchaseOrderWithBooster()
		{
			return context.PurchaseForm.Include(p => p.BoostingModel)
			.Include(p => p.CoachingModel)
			.Include(p => p.PlacementMatchesModel)
			.Include(p => p.TFTBoostingModel)
			.Include(p => p.TFTPlacementModel)
			.Include(p => p.WinBoostModel).Include(p => p.BoosterAssignedTo).Where(x => !x.AdminCompletionConfirmed);
		}

		public IEnumerable<PurchaseForm> GetAllPurchaseOrderAvailable()
		{
			return context.PurchaseForm.Where(x => x.JobAvailable)
			.Include(p => p.BoostingModel)
			.Include(p => p.CoachingModel)
			.Include(p => p.PlacementMatchesModel)
			.Include(p => p.TFTBoostingModel)
			.Include(p => p.TFTPlacementModel)
			.Include(p => p.WinBoostModel)
			.Include(p => p.Discount);
		}

		public IEnumerable<PurchaseForm> GetAllPurchaseOrdersByUser(ApplicationUser applicationUser)
		{
			return context.PurchaseForm.Where(x => x.BoosterAssignedTo == applicationUser)
			.Include(p => p.BoostingModel)
			.Include(p => p.CoachingModel)
			.Include(p => p.PlacementMatchesModel)
			.Include(p => p.TFTBoostingModel)
			.Include(p => p.TFTPlacementModel)
			.Include(p => p.WinBoostModel);
		}

		public PurchaseForm GetPurchaseForm(int Id)
		{
			return context.PurchaseForm.Include(p => p.PersonalInformation).FirstOrDefault(item => item.Id == Id);
		}

		public PurchaseForm GetPurchaseFormWithBooster(int Id)
		{
			return context.PurchaseForm.Include(x => x.BoosterAssignedTo).FirstOrDefault(item => item.Id == Id);
		}

		public int GetPurchaseFormWithBoosterCount(ApplicationUser applicationUser)
		{
			return context.PurchaseForm.Where(x => x.BoosterAssignedTo == applicationUser).Count();
		}

		public PurchaseForm GetPurchaseFormModelsIncludedByIdAndUser(int Id, ApplicationUser applicationUser)
		{
			return context.PurchaseForm.Where(x => x.BoosterAssignedTo == applicationUser).Include(p => p.PersonalInformation)
						.Include(p => p.BoostingModel)
						.Include(p => p.CoachingModel)
						.Include(p => p.PlacementMatchesModel)
						.Include(p => p.TFTBoostingModel)
						.Include(p => p.TFTPlacementModel)
						.Include(p => p.WinBoostModel)
						.FirstOrDefault(item => item.Id == Id);
		}

		public PurchaseForm GetPurchaseFormModelsIncludedById(int Id)
		{
			return context.PurchaseForm.Include(p => p.PersonalInformation)
						.Include(p => p.BoostingModel)
						.Include(p => p.CoachingModel)
						.Include(p => p.PlacementMatchesModel)
						.Include(p => p.TFTBoostingModel)
						.Include(p => p.TFTPlacementModel)
						.Include(p => p.WinBoostModel)
						.Include(p => p.BoosterAssignedTo)
						.FirstOrDefault(item => item.Id == Id);
		}

		public PurchaseForm Update(PurchaseForm purchaseFormChanges)
		{
			var entity = context.PurchaseForm.Include(x => x.BoosterAssignedTo).FirstOrDefault(item => item.Id == purchaseFormChanges.Id);

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
