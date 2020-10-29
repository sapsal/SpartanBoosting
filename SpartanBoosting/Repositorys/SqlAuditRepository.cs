using SpartanBoosting.Data;
using SpartanBoosting.Models;
using SpartanBoosting.Models.LeagueOfLegends_Models;
using SpartanBoosting.Models.Pricing;
using SpartanBoosting.Repositorys.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Repositorys
{
	public class SqlAuditRepository : IAuditRepository
	{
		private readonly ApplicationDbContext context;

		public SqlAuditRepository(ApplicationDbContext context)
		{
			this.context = context;
		}
		public LeagueOfLegendsAuditModel Add(LeagueOfLegendsAuditModel LeagueOfLegendsAuditModel)
		{
			context.LeagueOfLegendsAuditModel.Add(LeagueOfLegendsAuditModel);
			context.SaveChanges();
			return LeagueOfLegendsAuditModel;
		}
	}
}
