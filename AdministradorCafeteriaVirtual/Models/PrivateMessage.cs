

namespace AdministradorCafeteriaVirtual.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class PrivateMessage
    {
        [Key]
        public int idmessage { get; set; }
        
        [Column(Order = 0)]
        [ForeignKey("userRoom")]
        public int idRoom { get; set; }
        
        [Column(Order = 1)]
        [ForeignKey("userRoom")]
        public int idUser { get; set; }
        public string message { get; set; }
        public DateTime? date { get; set; }
       

        public virtual UserRoom userRoom { get; set; }
    }
}