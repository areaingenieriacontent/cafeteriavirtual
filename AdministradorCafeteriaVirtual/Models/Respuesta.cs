

namespace AdministradorCafeteriaVirtual.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Respuesta
    {
        [Key]
        public int idrespuesta { get; set; }
        public string contenido { get; set; }
        [ForeignKey("user")]
        public int idusuario { get; set; }
        public bool bestAnswer { get; set; }
        public bool enable { get; set; }
        [ForeignKey("pregunta")]
        public int idpregunta { get; set; }

        public virtual User user { get; set; }

        public virtual Pregunta pregunta { get; set; }
    }
}