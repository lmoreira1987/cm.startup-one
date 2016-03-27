using Know.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Know.MVC.ViewModels
{
    public class ApprovalStudentViewModel
    {
        public long Id { get; set; }
        public string Foto { get; set; }
        public string Nome { get; set; }
        public string Serie { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}