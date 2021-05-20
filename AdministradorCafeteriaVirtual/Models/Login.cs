
namespace AdministradorCafeteriaVirtual.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Login
    {
        [Key]
        public int idsession { get; set; }
        [ForeignKey("user")]
        public int userid { get; set; }

        public DateTime? logDate { get; set; }

        public string ip { get; set; }

        public string city { get; set; }

        public virtual User user { get; set; }
    }
}