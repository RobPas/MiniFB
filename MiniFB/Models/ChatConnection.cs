using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;
using MiniFB.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniFB.Models
{
    class ChatConnection
    {
        private Dictionary<string, string> _clients = new Dictionary<string, string>();


        //protected override Task OnConnectedAsync(IRequest request, string connectionId)
        //{
        //    _clients.Add(connectionId, string.Empty);
        //    ChatData chatData = new ChatData("Server", "A new user has joined the room.");
        //    return Connection.Broadcast(chatData);
        //}

        //protected override Task OnReceivedAsync(IRequest request, string connectionId, string data)
        //{
        //    ChatData chatData = JsonConvert.DeserializeObject<ChatData>(data);
        //    _clients[connectionId] = chatData.Name;
        //    return Connection.Broadcast(chatData);
        //}

        //protected override Task OnDisconnectAsync(IRequest request, string connectionId)
        //{
        //    string name = _clients[connectionId];
        //    ChatData chatData = new ChatData("Server", string.Format("{0} has left the room.", name));
        //    _clients.Remove(connectionId);
        //    return Connection.Broadcast(chatData);
        //}

    }
}
