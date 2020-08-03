using Microsoft.AspNetCore.Mvc;
using PayPal.Core;
using PayPal.v1.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Utils
{
	public static class PayPalPayment
	{
		public static string CreatePaymentRequest(string price)
		{
			//var environment = new LiveEnvironment("AbsLlwBzsLwTvG-6awsiklgFPeDNWlGctQ9MukFQl-VimUpPwBtTLpR5SX8Wyu0U_R8pg6mGxgrpzYiA", "EIFw-teU8tWyH7UBXgI7UftSXuJoB1aG51jkZMiRb23x39OaTd9kLOcKSVtb6FWK5vj1sSypW1kC9xUB");
			var environment = new SandboxEnvironment("ARXuDzN7ArL3ZiTG0_ebn-4u53kqetWWQSkM5UoVk5KZ_ClhTjSueiVJTnDuFvYtf4TnPxxJDRSJryWJ", "EL6FuAA6ocMA6rFtSWg7Ck-mZYMCq4W-G-huZPVsiOIT9zyI9z2Wh_-_Elv9GiiWP00S8fn28I5G-NFm");

			var client = new PayPalHttpClient(environment);

			var payment = new PayPal.v1.Payments.Payment()
			{
				Intent = "sale",
				Transactions = new List<Transaction>()
					{
						new Transaction()
						{
							Amount = new Amount()
							{
								Total = price,
								Currency = "EUR"
							}
						}
					},
				RedirectUrls = new RedirectUrls()
				{
					ReturnUrl = "https://localhost:44353/Quote/PurchaseQuote",
					CancelUrl = "https://www.spartanboosting.co.uk"
				},
				Payer = new Payer()
				{
					PaymentMethod = "paypal"
				}
			};

			PaymentCreateRequest request = new PaymentCreateRequest();
			request.RequestBody(payment);

			System.Net.HttpStatusCode statusCode;

			try
			{
				BraintreeHttp.HttpResponse response = client.Execute(request).Result;
				statusCode = response.StatusCode;
				Payment result = response.Result<Payment>();

				string redirectUrl = null;
				foreach (LinkDescriptionObject link in result.Links)
				{
					if (link.Rel.Equals("approval_url"))
					{
						redirectUrl = link.Href;
					}
				}

				if (redirectUrl == null)
				{
					// Didn't find an approval_url in response.Links
					//await context.Response.WriteAsync("Failed to find an approval_url in the response!");
				}
				else
				{
					return redirectUrl;
				}
			}
			catch (BraintreeHttp.HttpException ex)
			{
				statusCode = ex.StatusCode;
				var debugId = ex.Headers.GetValues("PayPal-Debug-Id").FirstOrDefault();
				//await context.Response.WriteAsync("Request failed!  HTTP response code was " + statusCode + ", debug ID was " + debugId);
			}

			return "";
		}

	}
}
