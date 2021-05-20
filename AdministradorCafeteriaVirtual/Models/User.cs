using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdministradorCafeteriaVirtual.Models
{
    
    public class User
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool enable { get; set; }
        public DateTime?firstlog { get; set; }
        public string email { get; set; }

        public virtual ICollection<Pregunta> preguntas { get; set; }
        public virtual ICollection<Login> logins { get; set; }
        public virtual ICollection<UserRoom> userrooms { get; set; }
        public virtual ICollection<ChatMessage> mensajes { get; set; }
        public virtual ICollection<Respuesta> respuestas { get; set; }
    }
}