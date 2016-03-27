//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Know.MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Disciplina
    {
        public Disciplina()
        {
            this.Perguntas = new HashSet<Pergunta>();
            this.ProfessorDisciplinas = new HashSet<ProfessorDisciplina>();
        }
    
        public long Id { get; set; }
        public long IdIdioma { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public System.DateTime DataCriacao { get; set; }
        public Nullable<System.DateTime> DataAtualizacao { get; set; }
        public bool Ativo { get; set; }
    
        public virtual Idioma Idioma { get; set; }
        public virtual ICollection<Pergunta> Perguntas { get; set; }
        public virtual ICollection<ProfessorDisciplina> ProfessorDisciplinas { get; set; }
    }
}
