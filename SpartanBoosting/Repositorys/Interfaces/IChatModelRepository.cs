using SpartanBoosting.Models;
using SpartanBoosting.Models.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Repositorys.Interfaces
{
	public interface IChatModelRepository
	{
		ChatModel GetChatModel(int Id);
		List<ChatModel> GetChatModelByPurchaseOrder(int PurchaseFormid);
		ChatModel Add(ChatModel chatModel);
	}
}
