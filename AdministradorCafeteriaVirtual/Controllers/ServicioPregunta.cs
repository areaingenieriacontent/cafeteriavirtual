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
        [Route("getpregunta")]
        public List<Pregunta> GetPreguntas(int userid)
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
        [HttpGet]
        [Route("AllCategories")]
        public List<Category> GetAllCategories()
        {
            return null;
        }
    }
}