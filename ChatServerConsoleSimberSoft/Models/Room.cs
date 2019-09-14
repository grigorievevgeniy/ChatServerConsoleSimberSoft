using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerConsoleSimberSoft.Models
{
    // На потом...
    class Room
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public List<Message> Messages { get; set; }
    }
}
