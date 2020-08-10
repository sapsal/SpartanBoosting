using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Utils
{
	public static class StripePayments
	{
		public static Charge StripePaymentsForm(Models.PersonalInformation PersonalInformation, string Price)
		{
			var customerService = new Stripe.CustomerService();
			var chargeService = new Stripe.ChargeService();
			var priceConverted = decimal.Parse(Price) * 100;
			var customer = customerService.Create(new Stripe.CustomerCreateOptions
			{
				Email = PersonalInformation.Email,
				Source = PersonalInformation.stripeToken,

			});

			return chargeService.Create(new Stripe.ChargeCreateOptions
			{
				Amount = (long)priceConverted,
				Description = "Spartan Boosting",
				Currency = "EUR",
				Customer = customer.Id
			});

		}
	}
}
