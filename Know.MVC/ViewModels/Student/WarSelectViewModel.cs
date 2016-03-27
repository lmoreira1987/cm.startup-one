using Know.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Know.MVC.ViewModels
{
    public class WarSelectViewModel
    {
        public List<Disciplina> Disciplinas { get; set; }
        public List<Serie> Series { get; set; }
        public List<UsuarioBatalhaViewModel> UsuarioBatalha { get; set; }
    }
}