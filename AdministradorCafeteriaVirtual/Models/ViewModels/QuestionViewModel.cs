using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdministradorCafeteriaVirtual.Models.ViewModels
{
    public class QuestionViewModel
    {
        public int errorCode { get; set; }
        public string content { get; set; }
        public int idCategory { get; set; }
        public int idUser { get; set; }
        public bool enabled { get; set; }
        public bool open { get; set; }
    }

    public class AnswerViewModel
    {
        public int errorCode { get; set; }
        public string content { get; set; }
        public int idUser { get; set; }
        public bool bestAnswer { get; set; }
        public bool enabled { get; set; }
        public int idQuestion { get; set; }
    }
}