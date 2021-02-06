using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SpartanBoosting.Utils
{
    public class Chat : Hub
    {
        public Task Send(string message)
        {
            return Clients.All.SendAsync("Send", message);
        }
    }
}
