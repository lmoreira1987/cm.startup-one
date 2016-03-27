using Know.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Know.MVC.ViewModels
{
    public class SchoolViewModel
    {
        public List<Idioma> Idiomas { get; set; }
        public List<Disciplina> Disciplinas { get; set; }
        public List<Serie> Series { get; set; }
        public List<Dificuldade> Dificuldades { get; set; }
        public List<Pergunta> Perguntas { get; set; }
    }
}