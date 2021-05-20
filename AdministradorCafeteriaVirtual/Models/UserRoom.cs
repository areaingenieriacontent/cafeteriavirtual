using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdministradorCafeteriaVirtual.Models
{

    public class UserRoom
    {

        [Key]
        [Column(Order = 0)]
        [ForeignKey("room")]
        public int idRoom { get; set; }
        [Key]
        [Column(Order = 1)]
        [ForeignKey("user")]
        public int idUser{ get; set; }
        public bool connected { get; set; }

        public virtual User user { get; set; }

        public virtual Room room { get; set; }
        public virtual ICollection<PrivateMessage> mensajes { get; set; }
    }
}