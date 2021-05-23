using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using AdministradorCafeteriaVirtual.Models;
using AdministradorCafeteriaVirtual.Models.ViewModels;
using System.Data.Entity;

namespace AdministradorCafeteriaVirtual.Controllers
{
    [RoutePrefix("api/cafeteria")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ServicioPreguntaController : ApiController
    {
        CafeteriaDbContext cafeteriaDbContext = new CafeteriaDbContext();

        [HttpPost]
        [Route("GetPregunta")]
        public Pregunta GetPregunta(int id)
        {
            Pregunta pregunta = cafeteriaDbContext.Preguntas.Find(id);
            return pregunta;
        }

        [HttpPost]
        [Route("PreguntasUsuario")]
        public List<Pregunta> GetPreguntasDeUsuario(int userid)
        {
            List<Pregunta> pregunta = cafeteriaDbContext.Preguntas.Where(o => o.idusuario == userid).ToList();
            return pregunta;
        }

        [HttpPost]
        [Route("AddQuestion")]
        public void addpregunta([FromUri] QuestionViewModel pregunta)
        {
            Pregunta newPregunta = new Pregunta
            {
                idCategoria=pregunta.idCategory,
                idusuario=pregunta.idUser,
                contenido=pregunta.content,
                open = pregunta.open,
                enable=pregunta.enabled
            };
            try
            {
                cafeteriaDbContext.Preguntas.Add(newPregunta);
                cafeteriaDbContext.SaveChanges();
            }
            catch
            {
                pregunta.errorCode = 300;
            }
        }

        [HttpPost]
        [Route("RemoveQuestion")]
        public bool RemovePregunta(int preguntaid)
        {
            Pregunta questionToRemove = cafeteriaDbContext.Preguntas.Find(preguntaid);
            cafeteriaDbContext.Preguntas.Remove(questionToRemove);
            cafeteriaDbContext.SaveChanges();
            return false;
        }

        [HttpPost]
        [Route("AnswerQuestion")]
        public bool AnswerQuestion([FromUri] AnswerViewModel answer)
        {
            if (cafeteriaDbContext.Preguntas.Find(answer.idQuestion)!=null){
                Respuesta answerToAdd = new Respuesta
                {
                    contenido = answer.content,
                    idusuario = answer.idUser,
                    bestAnswer = answer.bestAnswer,
                    enable = answer.enabled,
                    idpregunta = answer.idQuestion
                };
                cafeteriaDbContext.Respuestas.Add(answerToAdd);
                cafeteriaDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
       
    }
}