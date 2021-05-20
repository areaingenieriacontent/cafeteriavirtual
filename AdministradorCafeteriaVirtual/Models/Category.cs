using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdministradorCafeteriaVirtual.Models

{


    public class Category
    {
        [Key]
        public int id { get; set; }

        public string image { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public bool enable { get; set; }
        public virtual ICollection<Pregunta> preguntas { get; set; }
    }
}