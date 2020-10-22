using SpartanBoosting.Data;
using SpartanBoosting.Models;
using SpartanBoosting.Models.Pricing;
using SpartanBoosting.Repositorys.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Repositorys
{
	public class SqlChatModelRepository : IChatModelRepository
	{
		private readonly ApplicationDbContext context;

		public SqlChatModelRepository(ApplicationDbContext context)
		{
			this.context = context;
		}
		public List<ChatModel> GetChatModelByPurchaseOrder(PurchaseForm PurchaseForm)
		{
			return context.ChatModel.Where(x => x.purchaseFormId == PurchaseForm.Id).ToList();
		}
		public ChatModel GetChatModel(int Id)
		{
			return context.ChatModel.Where(x => x.Id == Id).FirstOrDefault();
		}
		public ChatModel Add(ChatModel chatModel)
		{
			context.ChatModel.Add(chatModel);
			context.SaveChanges();
			return chatModel;
		}
	}
}
