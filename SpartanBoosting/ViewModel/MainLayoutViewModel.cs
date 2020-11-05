using SpartanBoosting.Models.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.ViewModel
{
	public class MainLayoutViewModel
	{
		public LoginViewModel LoginModel { get; set; } = new LoginViewModel();
	}
}
