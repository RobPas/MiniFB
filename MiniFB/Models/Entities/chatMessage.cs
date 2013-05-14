using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniFB.Models.Entities
{
    public class chatMessage
    {
        public Guid ID { get; set; }
        public DateTime timestamp { get; set; }
        public string username { get; set; }
        public string sendtousername { get; set; }
        public string message { get; set; }

        //Skapa en statisk variabel som innehåller applikationens lista över alla chatmeddelanden
        public static List<chatMessage> AllChatMessages = new List<chatMessage>();
    }
}