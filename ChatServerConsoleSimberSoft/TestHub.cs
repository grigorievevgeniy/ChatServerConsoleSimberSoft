using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerConsoleSimberSoft
{
    [HubName("TestHub")]
    public class TestHub : Hub
    {
        public void SameMetod(string message)
        {
            Console.WriteLine(message);

            string newMessage = string.Format(@"{0} has a length of: {1}", message, message.Length);
            Clients.All.ReceiveLength(newMessage);
        }
    }
}
