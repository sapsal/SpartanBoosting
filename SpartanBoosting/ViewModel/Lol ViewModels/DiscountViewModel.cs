using SpartanBoosting.Models;

namespace SpartanBoosting.ViewModel.Lol_ViewModels
{
	public class DiscountViewModel
	{
		public int DicountPercentage { get; set; }
		public decimal Price { get; set; }
		public DiscountModel Discount { get; set; }
		public bool Success { get; set; }
	}
}
