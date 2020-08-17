using System;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using PayPalHttp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpartanBoosting.Utils
{
	public class PayPalV2Response
	{
		public string ApprovalURL { get; set; }
		public string CaptureURL { get; set; }
	}
	public static class PayPalV2
	{
		public static HttpClient client()
		{
			// Creating a sandbox environment
			//var environment = new SandboxEnvironment("ARXuDzN7ArL3ZiTG0_ebn-4u53kqetWWQSkM5UoVk5KZ_ClhTjSueiVJTnDuFvYtf4TnPxxJDRSJryWJ", "EL6FuAA6ocMA6rFtSWg7Ck-mZYMCq4W-G-huZPVsiOIT9zyI9z2Wh_-_Elv9GiiWP00S8fn28I5G-NFm");
			var environment = new LiveEnvironment("AbsLlwBzsLwTvG-6awsiklgFPeDNWlGctQ9MukFQl-VimUpPwBtTLpR5SX8Wyu0U_R8pg6mGxgrpzYiA", "EIFw-teU8tWyH7UBXgI7UftSXuJoB1aG51jkZMiRb23x39OaTd9kLOcKSVtb6FWK5vj1sSypW1kC9xUB");

			// Creating a client for the environment
			PayPalHttpClient client = new PayPalHttpClient(environment);
			return client;
		}

		public static PayPalV2Response createOrder(string price)
		{
			HttpResponse response;
			PayPalV2Response responsePaypal = new PayPalV2Response();
			// Construct a request object and set desired parameters
			// Here, OrdersCreateRequest() creates a POST request to /v2/checkout/orders
			var order = new OrderRequest()
			{
				CheckoutPaymentIntent = "CAPTURE",
				PurchaseUnits = new List<PurchaseUnitRequest>()
				{
					new PurchaseUnitRequest()
					{
						AmountWithBreakdown = new AmountWithBreakdown()
						{
							CurrencyCode = "EUR",
							Value = price
						}
					}
				},
				ApplicationContext = new ApplicationContext()
				{
					//ReturnUrl = "https://localhost:44353/Quote/PurchaseQuote",
					ReturnUrl = "https://www.spartanboosting.com/Quote/PurchaseQuote",
					CancelUrl = "https://www.spartanboosting.com"
				}
			};


			// Call API with your client and get a response for your call
			var request = new OrdersCreateRequest();
			request.Prefer("return=representation");
			request.RequestBody(order);
			response = client().Execute(request).Result;
			var statusCode = response.StatusCode;
			Order result = response.Result<Order>();
			foreach (LinkDescription link in result.Links)
			{
				if (link.Rel == "approve")
				{
					responsePaypal.ApprovalURL = link.Href;
				}
				if (link.Rel == "capture")
				{
					responsePaypal.CaptureURL = link.Href;
				}
			}
			return responsePaypal;
		}

		public static HttpResponse captureOrder(string id)
		{
			// Construct a request object and set desired parameters
			// Replace ORDER-ID with the approved order id from create order
			string[] splitUrl = id.Split('/');
			if (splitUrl.Length > 0)
			{
				var request = new OrdersCaptureRequest(splitUrl[6]);
				request.RequestBody(new OrderActionRequest());
				HttpResponse response = client().Execute(request).Result;
				var statusCode = response.StatusCode;
				Order result = response.Result<Order>();
				return response;
			}
			else
				return null;
		}
	}
}
