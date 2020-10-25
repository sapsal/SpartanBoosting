using SpartanBoosting.Models.Pricing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Models
{
	public class ChatModel
	{
		[Key]
		public int Id { get; set; }
		public ApplicationUser Sender { get; set; }
		public ApplicationUser Reciever { get; set; }
		public string Message { get; set; }
		public DateTime DateTimeSent { get; set; }
		[ForeignKey("PurchaseFor")]
		public int purchaseFormId { get; set; }
	}
}
