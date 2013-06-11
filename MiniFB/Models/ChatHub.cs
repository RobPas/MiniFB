using Microsoft.AspNet.SignalR;
using MiniFB.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniFB.Models
{
    class ChatHub : Hub
    {
        
        public void Distribute(string name, string message)
        {
            // Call the broadcastMessage method to update all clients.
            Clients.All.broadcastMessage(name, message);
        }

        public void Connect(string userName) { }

        public void SendMessageToAll(string userName, string message) { }

        public void SendPrivateMessage(string toUserId, string message) { }

       }
}
