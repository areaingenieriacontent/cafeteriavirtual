

namespace AdministradorCafeteriaVirtual.Models
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Pregunta
    {
        [Key]
        public int idPregunta { get; set; }

        [ForeignKey("category")]
        public int idCategoria { get; set; }
        [ForeignKey("user")]
        public int idusuario { get; set; }

        public string contenido { get; set; }

        public bool open { get; set; }

        public bool enable { get; set; }

        public virtual Category category {get; set;}
        public virtual User user { get; set; }

        public virtual ICollection<Respuesta> respuestas { get; set; }
    }
}