using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpartanBoosting.Models.Pricing;
using System.IO;

namespace SpartanBoosting
{
	public static class ObjectFactory
	{
		public static List<SoloBoostPricing> SoloBoostPricing = new List<SoloBoostPricing>();
		public static List<DuoBoostPricing> DuoBoostPricing = new List<DuoBoostPricing>();
		//work computer
		private static string fileName = @"C:\Users\warder.SGSCO\source\repos\robertwardellSGS\SpartanBoosting\SpartanBoosting\Gameboost_Prices_22062020_-_TFT_Update.xlsx";
		//my computer
		// private static string fileName = @"C:\Users\bobby\Source\Repos\SpartanBoosting\SpartanBoosting\Gameboost_Prices_22062020_-_TFT_Update.xlsx";
		private static FileInfo file = new FileInfo(fileName);
		public static void LoadSoloBoost()
		{
			using (ExcelPackage package = new ExcelPackage(file))
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
		}

		public static void LoadDuoBoost()
		{
			using (ExcelPackage package = new ExcelPackage(file))
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

						if (worksheet.Cells[4, col].Value.ToString() == "Current Division ")
						{
							CurrentDivision = $"{worksheet.Cells[row, col].Value}";
						}
						if (worksheet.Cells[4, col].Value.ToString() == "Current LP ")
						{
							CurrentLP = $"{worksheet.Cells[row, col].Value}";
						}
						if (worksheet.Cells[4, col].Value.ToString() == "Required Division ")
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
		}
	}
}
