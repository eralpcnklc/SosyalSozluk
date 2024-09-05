using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVCProje
{
    public class ChatHub : Hub
    {
        private static Dictionary<string, string> users = new Dictionary<string, string>();
        public override Task OnConnected()
        {
            string userName = Context.User.Identity.Name;
            if (!users.ContainsKey(userName))
            {
              users.Add(userName, Context.ConnectionId);
            }
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            string userName = Context.User.Identity.Name;
            if (users.ContainsKey(userName))
            {
                users.Remove(userName);
            }
            return base.OnDisconnected(stopCalled);
        }
        public void SendMessageToUser(string userName, string message)
        {
            if (users.TryGetValue(userName, out string connectionId))
            {
                Clients.Client(connectionId).SendAsync("ReceiveMessage", message);
            }
        }
    }
}