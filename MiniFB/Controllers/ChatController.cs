using MiniFB.Models.Entities;
using MiniFB.Models.Repositories;
using MiniFB.Models.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniFB.Controllers
{
    public class ChatController : Controller
    {

        private IRepository<User> _userRepo;

        public ChatController()
        {
            _userRepo = new Repository<User>();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Random()
        {

            List<User> listusers =_userRepo.FindAll().ToList();

            Random r = new Random();
            int randomNumber = r.Next(listusers.Count);

            User randuser = listusers.GetRange(randomNumber, 1).First();

            return View(randuser);
        }

        
        public ActionResult GetChatMessages(DateTime lastCheck)
        {

            //Skriv ut i Visual Studios debug-fönster
            Debug.WriteLine("** LastCheck=" + lastCheck.ToString("G"));

            //Hämta alla chat-meddelanden med en timestamp senare än lastCheck samt en timestamp innan DateTime.Now (filtrera bort saker från framtiden)
            List<chatMessage> msgs = chatMessage.AllChatMessages.Where(m => m.timestamp > lastCheck && m.timestamp < DateTime.Now).OrderBy(m => m.timestamp).ToList();

            //Returnera listan i JSON-format (och tillåt GET-requests)
            return Json(msgs, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult GetMyChatMessages()
        {
            List<chatMessage> msgs = chatMessage.AllChatMessages.Where(m => m.username == User.Identity.Name).OrderBy(m => m.timestamp).ToList();

            return Json(msgs, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult StoreChatMessage(string newMessage)
        {
            
            //Skapa en tidsstämpel utan millisekunder
            DateTime tstamp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, 0);

            //Lägg till chatmeddelandet i listan
            chatMessage.AllChatMessages.Add(new chatMessage { timestamp = tstamp, username = User.Identity.Name, message = newMessage });

            //Returnera något
            return Json("ok");
        }

        public ActionResult StoreChatMessageToRandom(string newMessage, Guid sendToID)
        {
            var SendToUsername = _userRepo.FindByID(sendToID).UserName;
            
            DateTime tstamp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, 0);

            chatMessage.AllChatMessages.Add(new chatMessage { timestamp = tstamp, sendtousername = SendToUsername, username = User.Identity.Name, message = newMessage });

            return Json("ok");
        }



        public ActionResult SignalRChat()
        {
            
            return View();
        }

    }
}
