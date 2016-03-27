using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Know.MVC.Models;

namespace Know.MVC.ViewModels
{
    public class StudentViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public List<Serie> Series  { get; set; }
    }
}