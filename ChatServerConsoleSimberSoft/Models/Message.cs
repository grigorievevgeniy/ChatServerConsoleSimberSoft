﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerConsoleSimberSoft.Models
{
    class Message
    {
        public string Text { get; set; }
        public User User { get; set; }
        public DateTime Time { get; set; }
    }
}
