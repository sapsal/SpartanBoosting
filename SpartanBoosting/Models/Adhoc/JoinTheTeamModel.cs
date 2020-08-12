using System.ComponentModel.DataAnnotations;

namespace SpartanBoosting.Models.Adhoc
{
	public class JoinTheTeamModel
	{
		[Key]
		public int Id { get; set; }
		public string Type { get; set; }
		public string Age { get; set; }
		public string Country { get; set; }
		public string Language { get; set; }
		public string CurrentRank { get; set; }
		public string Servers { get; set; }
		public string MainLanes { get; set; }
		public string MainChampions { get; set; }
		public string NumberOfHoursAvailable { get; set; }
		public string DuoBoost { get; set; }
		public string DiscordName { get; set; }
		public string Email { get; set; }
		public string Background { get; set; }
		public string BoostingFeePrevious { get; set; }
	}
}
