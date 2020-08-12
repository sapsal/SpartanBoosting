using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SpartanBoosting.Models
{
	public class IpInfo
	{
		//country
		//public IpInfoLocation location { get; set; }
		[Key]
		public int Id { get; set; }
		public string Ip { get; set; }
		public string Country { get; set; }
		public IpInfo GetCurrentIpInfo(string ip)
		{
			string accessKey = "3bb2ef67367dab";
			string info = new WebClient().DownloadString($"https://ipinfo.io/{ip}/json?token={accessKey}");
			return JsonConvert.DeserializeObject<IpInfo>(info);
		}
	}
	public class IpInfoCountry
	{
		[Key]
		public int Id { get; set; }
		public string Area { get; set; }
		public string Calling_Code { get; set; }
		public string Capital { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
	}
}
