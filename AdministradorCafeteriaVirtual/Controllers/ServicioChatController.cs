using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using AdministradorCafeteriaVirtual.Models;
using System.Data.Entity;

namespace AdministradorCafeteriaVirtual.Controllers
{
    [RoutePrefix("api/cafeteria")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ServicioChatController : ApiController
    {
        CafeteriaDbContext cafeteriaDbContext = new CafeteriaDbContext();

        [HttpGet]
        [Route("usermessages")]
        public List<ChatMessage> getusermessages(int idusuario)
        {
            List<ChatMessage> mensajesdeusuario = cafeteriaDbContext.ChatMessages.Where(o => o.idUser == idusuario).ToList();
            return mensajesdeusuario;
        }

        [HttpPost]
        [Route("uploadmessage")]
        public void uploadmessage(string message, int iduser)
        {
            ChatMessage newChatmessage = new ChatMessage();
            newChatmessage.idUser = iduser;
            newChatmessage.date = DateTime.Now;
            newChatmessage.message = message;
            cafeteriaDbContext.ChatMessages.Add(newChatmessage);
            cafeteriaDbContext.SaveChanges();
        }

        [HttpGet]
        [Route("Allmessages")]
        public List<ChatMessage> allmessages()
        {
            List<ChatMessage> chatMessages = cafeteriaDbContext.ChatMessages.OrderBy(x=>x.date).ToList();
            return chatMessages;
        }
    }
}