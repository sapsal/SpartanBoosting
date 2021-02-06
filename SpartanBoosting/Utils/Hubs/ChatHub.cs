using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SpartanBoosting.Utils.Hubs
{
	/// <summary>
	/// The SignalR hub 
	/// </summary>
	public class ChatHub : Hub
	{
		public async Task Send(string userId)
		{
			var message = $"Send message to you with user id {userId}";
			await Clients.Client(userId).SendAsync("ReceiveMessage", message);
		}

		public async Task AddToGroup(string connectionId, string groupName)
		{
			await Groups.AddToGroupAsync(connectionId, groupName);
		}

		public async Task SendToGroup(string groupName, string message, string connectionId)
		{
			await Clients.Group(groupName).SendAsync("ReceiveMessage", message, connectionId);
		}

		public string GetConnectionId()
		{
			return Context.ConnectionId;
		}

	}
}
