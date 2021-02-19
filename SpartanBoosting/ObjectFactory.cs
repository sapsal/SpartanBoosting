using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpartanBoosting.Models.Pricing;
using System.IO;
using System.Reflection;
using System.Collections.Specialized;

namespace SpartanBoosting
{
	public static class ObjectFactory
	{
		public static int BoosterPercentage;
		public static List<SoloBoostPricing> SoloBoostPricing = new List<SoloBoostPricing>();
		public static List<DuoBoostPricing> DuoBoostPricing = new List<DuoBoostPricing>();
		public static List<WinBoostPricing> WinBoostPricing = new List<WinBoostPricing>();
		public static List<WinBoostPricing> PlacementBoostPricing = new List<WinBoostPricing>();
		public static List<WinBoostPricing> TFTPlacementBoostPricing = new List<WinBoostPricing>();
		public static List<TFTSoloBoostPricing> TFTSoloBoostPricing = new List<TFTSoloBoostPricing>();
		private static string fileName = Path.Combine(Environment.CurrentDirectory, @"wwwroot\Prices.xlsx");
		private static FileInfo file = new FileInfo(fileName);
		public static string instanceName { get; set; }
		

		public static void LoadPricing()
		{
			using (ExcelPackage package = new ExcelPackage(file))
			{
				LoadSoloBoost(package);
				LoadDuoBoost(package);
				LoadWinBoost(package);
				LoadPlacementBoost(package);
				LoadTFTSoloBoost(package);
				LoadTFTPlacementBoost(package);
			}
		}

		public static void LoadSoloBoost(ExcelPackage package)
		{
			ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
			int rowCount = worksheet.Dimension.Rows;
			int ColCount = worksheet.Dimension.Columns;

			string CurrentDivision = string.Empty;
			string CurrentLP = string.Empty;
			string RequiredDivision = string.Empty;
			string GameboostPrice = string.Empty;
			string OurPrice = string.Empty;
			for (int row = 5; row <= rowCount; row++)
			{
				for (int col = 1; col <= ColCount; col++)
				{

					if (worksheet.Cells[4, col].Value.ToString() == "Current Division")
					{
						CurrentDivision = $"{worksheet.Cells[row, col].Value}";
					}
					if (worksheet.Cells[4, col].Value.ToString() == "Current LP")
					{
						CurrentLP = $"{worksheet.Cells[row, col].Value}";
					}
					if (worksheet.Cells[4, col].Value.ToString() == "Required Division")
					{
						RequiredDivision = $"{worksheet.Cells[row, col].Value}";
					}
					if (worksheet.Cells[4, col].Value.ToString() == "Gameboost Price")
					{
						GameboostPrice = $"{worksheet.Cells[row, col].Value}";
					}
					if (worksheet.Cells[4, col].Value.ToString() == "Our Price")
					{
						OurPrice = $"{worksheet.Cells[row, col].Value}";
						SoloBoostPricing.Add(new SoloBoostPricing { CurrentDivision = CurrentDivision, CurrentLP = CurrentLP, GameboostPrice = GameboostPrice, OurPrice = OurPrice, RequiredDivision = RequiredDivision });
						RequiredDivision = string.Empty;
						GameboostPrice = string.Empty;
						OurPrice = string.Empty;
					}
				}
				CurrentDivision = string.Empty;
				CurrentLP = string.Empty;
			}
		}

		public static void LoadDuoBoost(ExcelPackage package)
		{
			ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
			int rowCount = worksheet.Dimension.Rows;
			int ColCount = worksheet.Dimension.Columns;

			string CurrentDivision = string.Empty;
			string CurrentLP = string.Empty;
			string RequiredDivision = string.Empty;
			string GameboostRegularPrice = string.Empty;
			string OurRegularPrice = string.Empty;
			string GameboostPremiumPrice = string.Empty;
			string OurPremiumPrice = string.Empty;
			for (int row = 5; row <= rowCount; row++)
			{
				for (int col = 1; col <= ColCount; col++)
				{

					if (worksheet.Cells[4, col].Value.ToString() == "Current Division")
					{
						CurrentDivision = $"{worksheet.Cells[row, col].Value}";
					}
					if (worksheet.Cells[4, col].Value.ToString() == "Current LP")
					{
						CurrentLP = $"{worksheet.Cells[row, col].Value}";
					}
					if (worksheet.Cells[4, col].Value.ToString() == "Required Division")
					{
						RequiredDivision = $"{worksheet.Cells[row, col].Value}";
					}
					if (worksheet.Cells[4, col].Value.ToString() == "Gameboost Regular Price")
					{
						GameboostRegularPrice = $"{worksheet.Cells[row, col].Value}";
					}
					if (worksheet.Cells[4, col].Value.ToString() == "Our Regular Price")
					{
						OurRegularPrice = $"{worksheet.Cells[row, col].Value}";
					}
					if (worksheet.Cells[4, col].Value.ToString() == " Gameboost Premium Price")
					{
						GameboostPremiumPrice = $"{worksheet.Cells[row, col].Value}";
					}
					if (worksheet.Cells[4, col].Value.ToString() == "Our Premium Price")
					{
						OurPremiumPrice = $"{worksheet.Cells[row, col].Value}";
						DuoBoostPricing.Add(new DuoBoostPricing
						{
							CurrentDivision = CurrentDivision,
							CurrentLP = CurrentLP,
							GameboostRegularPrice = GameboostRegularPrice,
							OurRegularPrice = OurRegularPrice,
							GameboostPremiumPrice = GameboostPremiumPrice,
							OurPremiumPrice = OurPremiumPrice,
							RequiredDivision = RequiredDivision
						});
						RequiredDivision = string.Empty;
						GameboostRegularPrice = string.Empty;
						OurRegularPrice = string.Empty;
						GameboostPremiumPrice = string.Empty;
						OurPremiumPrice = string.Empty;
					}
				}
				CurrentDivision = string.Empty;
				CurrentLP = string.Empty;
			}
		}

		public static void LoadWinBoost(ExcelPackage package)
		{
			ExcelWorksheet worksheet = package.Workbook.Worksheets[2];
			int rowCount = worksheet.Dimension.Rows;
			int ColCount = worksheet.Dimension.Columns;

			string LastSeasonStanding = string.Empty;
			string NumberOfGames = string.Empty;
			string GameboostPrice = string.Empty;
			string OurPrice = string.Empty;
			for (int row = 5; row <= rowCount; row++)
			{
				for (int col = 1; col <= ColCount; col++)
				{

					if (worksheet.Cells[4, col].Value.ToString() == "Last Season Standing")
					{
						LastSeasonStanding = $"{worksheet.Cells[row, col].Value}";
					}
					if (worksheet.Cells[4, col].Value.ToString() == "Number of Games")
					{
						NumberOfGames = $"{worksheet.Cells[row, col].Value}";
					}
					if (worksheet.Cells[4, col].Value.ToString() == "Gameboost Price")
					{
						GameboostPrice = $"{worksheet.Cells[row, col].Value}";
					}
					if (worksheet.Cells[4, col].Value.ToString() == "Our Price")
					{
						OurPrice = $"{worksheet.Cells[row, col].Value}";
						WinBoostPricing.Add(new WinBoostPricing { LastSeasonStanding = LastSeasonStanding, NumberOfGames = NumberOfGames, GameboostPrice = GameboostPrice, OurPrice = OurPrice });
						NumberOfGames = string.Empty;
						GameboostPrice = string.Empty;
						OurPrice = string.Empty;
					}
				}
				LastSeasonStanding = string.Empty;
			}
		}

		public static void LoadPlacementBoost(ExcelPackage package)
		{
			ExcelWorksheet worksheet = package.Workbook.Worksheets[3];
			int rowCount = worksheet.Dimension.Rows;
			int ColCount = worksheet.Dimension.Columns;

			string LastSeasonStanding = string.Empty;
			string NumberOfGames = string.Empty;
			string GameboostPrice = string.Empty;
			string OurPrice = string.Empty;
			for (int row = 5; row <= rowCount; row++)
			{
				for (int col = 1; col <= 31; col++)
				{

					if (worksheet.Cells[4, col].Value.ToString() == "Last Season Standing")
					{
						LastSeasonStanding = $"{worksheet.Cells[row, col].Value}";
					}
					if (worksheet.Cells[4, col].Value.ToString() == "Number of Games")
					{
						NumberOfGames = $"{worksheet.Cells[row, col].Value}";
					}
					if (worksheet.Cells[4, col].Value.ToString() == "Gameboost Price")
					{
						GameboostPrice = $"{worksheet.Cells[row, col].Value}";
					}
					if (worksheet.Cells[4, col].Value.ToString() == "Our Price")
					{
						OurPrice = $"{worksheet.Cells[row, col].Value}";
						PlacementBoostPricing.Add(new WinBoostPricing { LastSeasonStanding = LastSeasonStanding, NumberOfGames = NumberOfGames, GameboostPrice = GameboostPrice, OurPrice = OurPrice });
						NumberOfGames = string.Empty;
						GameboostPrice = string.Empty;
						OurPrice = string.Empty;
					}
				}
				LastSeasonStanding = string.Empty;
			}
		}

		public static void LoadTFTSoloBoost(ExcelPackage package)
		{
			ExcelWorksheet worksheet = package.Workbook.Worksheets[4];
			int rowCount = worksheet.Dimension.Rows;
			int ColCount = worksheet.Dimension.Columns;

			string CurrentDivision = string.Empty;
			string CurrentLP = string.Empty;
			string RequiredDivision = string.Empty;
			string GameboostRegularPrice = string.Empty;
			string OurRegularPrice = string.Empty;
			for (int row = 5; row <= rowCount; row++)
			{
				for (int col = 1; col <= ColCount; col++)
				{

					if (worksheet.Cells[4, col].Value.ToString() == "Current Division")
					{
						CurrentDivision = $"{worksheet.Cells[row, col].Value}";
					}
					if (worksheet.Cells[4, col].Value.ToString() == "Current LP")
					{
						CurrentLP = $"{worksheet.Cells[row, col].Value}";
					}
					if (worksheet.Cells[4, col].Value.ToString() == "Required Division")
					{
						RequiredDivision = $"{worksheet.Cells[row, col].Value}";
					}
					if (worksheet.Cells[4, col].Value.ToString() == "Gameboost Regular Price")
					{
						GameboostRegularPrice = $"{worksheet.Cells[row, col].Value}";
					}
					if (worksheet.Cells[4, col].Value.ToString() == "Our Regular Price")
					{
						OurRegularPrice = $"{worksheet.Cells[row, col].Value}";
						TFTSoloBoostPricing.Add(new TFTSoloBoostPricing { CurrentDivision = CurrentDivision, CurrentLP = CurrentLP, GameboostRegularPrice = GameboostRegularPrice, OurRegularPrice = OurRegularPrice, RequiredDivision = RequiredDivision });
						RequiredDivision = string.Empty;
						GameboostRegularPrice = string.Empty;
						OurRegularPrice = string.Empty;
					}
				}
				CurrentDivision = string.Empty;
				CurrentLP = string.Empty;
			}
		}

		public static void LoadTFTPlacementBoost(ExcelPackage package)
		{
			ExcelWorksheet worksheet = package.Workbook.Worksheets[5];
			int rowCount = worksheet.Dimension.Rows;
			int ColCount = worksheet.Dimension.Columns;

			string LastSeasonStanding = string.Empty;
			string NumberOfGames = string.Empty;
			string GameboostPrice = string.Empty;
			string OurPrice = string.Empty;
			for (int row = 5; row <= rowCount; row++)
			{
				for (int col = 1; col <= 16; col++)
				{

					if (worksheet.Cells[4, col].Value.ToString() == "Last Season Standing")
					{
						LastSeasonStanding = $"{worksheet.Cells[row, col].Value}";
					}
					if (worksheet.Cells[4, col].Value.ToString() == "Number of Games")
					{
						NumberOfGames = $"{worksheet.Cells[row, col].Value}";
					}
					if (worksheet.Cells[4, col].Value.ToString() == "Gameboost Price")
					{
						GameboostPrice = $"{worksheet.Cells[row, col].Value}";
					}
					if (worksheet.Cells[4, col].Value.ToString() == "Our Price")
					{
						OurPrice = $"{worksheet.Cells[row, col].Value}";
						TFTPlacementBoostPricing.Add(new WinBoostPricing { LastSeasonStanding = LastSeasonStanding, NumberOfGames = NumberOfGames, GameboostPrice = GameboostPrice, OurPrice = OurPrice });
						NumberOfGames = string.Empty;
						GameboostPrice = string.Empty;
						OurPrice = string.Empty;
					}
				}
				LastSeasonStanding = string.Empty;
			}
		}
	}
}
