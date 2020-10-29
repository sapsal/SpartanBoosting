using SpartanBoosting.Models;
using SpartanBoosting.Models.LeagueOfLegends_Models;
using SpartanBoosting.Models.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Repositorys.Interfaces
{
	public interface IAuditRepository
	{
		LeagueOfLegendsAuditModel Add(LeagueOfLegendsAuditModel LeagueOfLegendsAuditModel);
	}
}
