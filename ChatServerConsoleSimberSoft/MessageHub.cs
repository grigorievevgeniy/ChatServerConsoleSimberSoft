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

            // Добавление сообщений в архив
            Messages.Add(new Message { Text = message, Time = DateTime.Now, User = Users.Single(x => x.Login == user) });

        }

        // TODO доделать метод коннект
        public void Connect(string userName)
        {
            var id = Context.ConnectionId;

            if (!Users.Any(x => x.Login == userName))
            {
                Users.Add(new User { ConnectionId = id, Login = userName });

                // Посылаем сообщение текущему пользователю
                Clients.Caller.ReceiveLength(GetAllOldMessage());
                Clients.Caller.ReceiveLength(userName + ", Вы присоединились к чату");

                // Посылаем сообщение всем пользователям, кроме текущего
                Clients.AllExcept(id).ReceiveLength("К нам присоединился " + userName);
            }
        }

        private string GetAllOldMessage()
        {
            if (Messages.Count == 0)
            {
                return "*** Старых сообщений нет ***";
            }
            else
            {
                string allOldMessage = "***  Старые сообщения  ***";
                for (int i = Messages.Count - 1; i >= 0; i--)
                {
                    allOldMessage += "\r\n" + Messages[i].User.Login + ": " + Messages[i].Text;
                }
                return allOldMessage;
            }
        }
    }
}
