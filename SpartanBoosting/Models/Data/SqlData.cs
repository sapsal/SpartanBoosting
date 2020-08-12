using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Models.Data
{
	public class SqlData : DbContext
	{
		public string DefaultConnection { get; set; }
	}
}
