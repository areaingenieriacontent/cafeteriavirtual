

namespace AdministradorCafeteriaVirtual.Models
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Room
    {   
       [Key]
       public int idroom { set; get;}
        public string name { set; get; }

        public bool enable { set; get; }

        public int sits { set; get; }
        public virtual ICollection<UserRoom> userRooms { get; set; }
    }
}