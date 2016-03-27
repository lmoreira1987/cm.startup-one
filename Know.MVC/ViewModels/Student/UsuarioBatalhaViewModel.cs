using Know.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Know.MVC.ViewModels
{
    public class UsuarioBatalhaViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Pais { get; set; }
        public string Escola { get; set; }
        public string Foto { get; set; }
    }
}