using Microsoft.AspNet.SignalR;
using MiniFB.Models;
using MiniFB.Models.Entities;
using MiniFB.Models.Repositories;
using MiniFB.Models.Repositories.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniFB.Hubs
{
    public class ChatHub : Hub
    {
        private IRepository<User> _userRepo;
        public ChatHub (){
            _userRepo = new Repository<User>();
        }
        public void Distribute(string name, string message)
        {
            var user = _userRepo.FindAll(u => u.UserName == name).FirstOrDefault();

            Clients.All.broadcastMessage(name, message, user.ProfileImageUrl, DateTime.Now.ToString("HH:mm:ss"));
        }

        public void Connect(string userName) { }

        public void SendMessageToAll(string userName, string message) { }

        public void SendPrivateMessage(string toUserId, string message) { }

       }
}
