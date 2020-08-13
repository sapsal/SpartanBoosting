using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SpartanBoosting.Models.ManageViewModels
{
    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
    }
}
