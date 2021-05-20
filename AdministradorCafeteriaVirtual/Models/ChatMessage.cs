

namespace AdministradorCafeteriaVirtual.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class ChatMessage
    {
        [Key]
        public int idMessage { get; set; }
        [ForeignKey("user")]
        public int idUser { get; set; }

        public DateTime ? date { get; set; }

        public string message { get; set; }

        public virtual User user { get; set; }
    }
}