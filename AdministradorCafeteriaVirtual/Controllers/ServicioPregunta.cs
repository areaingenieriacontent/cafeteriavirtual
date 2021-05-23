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
    public class ServicioPregunta : ApiController
    {
        CafeteriaDbContext cafeteriaDbContext = new CafeteriaDbContext();

        [HttpGet]
        [Route("GetPregunta")]
        public Pregunta GetPregunta(int id)
        {
            Pregunta pregunta = cafeteriaDbContext.Preguntas.Where(o => o.idPregunta == id).ToList()[0];
            return pregunta;
        }
        [HttpGet]
        [Route("getpreguntasdeusuario")]
        public List<Pregunta> GetPreguntasDeUsuario(int userid)
        {
            List<Pregunta> pregunta = cafeteriaDbContext.Preguntas.Where(o => o.idusuario == userid).ToList();
            return pregunta;
        }
        [HttpPost]
        [Route("addpregunta")]
        public void addpregunta(int idcategoria, int idusuario)
        {
            Pregunta newPregunta = new Pregunta();
            newPregunta.idCategoria = idcategoria;
            newPregunta.idusuario = idusuario;
            cafeteriaDbContext.Preguntas.Add(newPregunta);
            cafeteriaDbContext.SaveChanges();
        }
        [HttpPost]
        [Route("RemovePregunta")]
        public void RemovePregunta(int userid, int preguntaid)
        {
           
        }
       
    }
}