using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniFB.Models
{
    
        public class ChatData
        {
            public string Name { get; set; }
            public string Message { get; set; }

            public ChatData()
            {
            }

            public ChatData(string name, string message)
            {
                Name = name;
                Message = message;
            }
        }
    
}