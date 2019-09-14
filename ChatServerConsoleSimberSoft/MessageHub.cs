using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerConsoleSimberSoft
{
    [HubName("MessageHub")]
    public class MessageHub : Hub
    {
        public void SendMessage(string user, string message)
        {
            Console.WriteLine(message);

            string FullMessage = string.Format(user + ": " + message);
            Clients.All.ReceiveLength(FullMessage);
        }
    }
}
