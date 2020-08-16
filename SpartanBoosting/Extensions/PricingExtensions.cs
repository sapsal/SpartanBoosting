using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Extensions
{
	public static class PricingExtensions
	{
		public static double RoundUp(double input, int places)
		{
			double multiplier = Math.Pow(10, Convert.ToDouble(places));
			return Math.Ceiling(input * multiplier) / multiplier;
		}
		public static double BoosterPay(string Pricing)
		{
			decimal price = decimal.Parse(Pricing);
			price = (price / 100) * ObjectFactory.BoosterPercentage;
			return RoundUp((double)price, 2);
		}
	}
}
