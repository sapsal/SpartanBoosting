using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
namespace SpartanBoosting.Data.DataContext
{
	public class AppConfiguration
	{
		public string sqlConnectionString { get; set; }

		//constructor
		public AppConfiguration()
		{
			var configBuilder = new ConfigurationBuilder();
			var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
			configBuilder.AddJsonFile(path, false);
			var root = configBuilder.Build();
			var appSetting = root.GetSection("ConnectionStrings:ApplicationDbContextConnection");
			sqlConnectionString = appSetting.Value;
		}
	}
}
