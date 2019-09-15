using ChatServerConsoleSimberSoft.Models;
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
        static List<User> Users = new List<User>();
        static List<Message> Messages = new List<Message>();

        public void SendMessage(string user, string message)
        {
            Console.WriteLine(message);

            string FullMessage = string.Format(user + ": " + message);
            Clients.All.ReceiveLength(FullMessage);

            Messages.Add(new Message { Text = FullMessage, Time = DateTime.Now, UserName = user });

            // Сначала надо реализовать добавление пользователей.
            //Messages.Add(new Message { Text = message, Time = DateTime.Now, User = Users.Single(x => x.Login == user) });

        }

        public void Connect(string userName)
        {
            var id = Context.ConnectionId;


            if (!Users.Any(x => x.ConnectionId == id))
            {
                Users.Add(new User { ConnectionId = id, Login = userName });

                // Посылаем сообщение текущему пользователю
                Clients.Caller.onConnected(id, userName, Users);

                // Посылаем сообщение всем пользователям, кроме текущего
                Clients.AllExcept(id).onNewUserConnected(id, userName);
            }
        }
    }
}
