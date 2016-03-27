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
    
    public partial class Idioma
    {
        public Idioma()
        {
            this.Dificuldades = new HashSet<Dificuldade>();
            this.Disciplinas = new HashSet<Disciplina>();
            this.Menus = new HashSet<Menu>();
            this.Perguntas = new HashSet<Pergunta>();
            this.Respostas = new HashSet<Resposta>();
            this.Series = new HashSet<Serie>();
        }
    
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Flag { get; set; }
        public System.DateTime DataCriacao { get; set; }
        public Nullable<System.DateTime> DataAtualizacao { get; set; }
        public bool Ativo { get; set; }
    
        public virtual ICollection<Dificuldade> Dificuldades { get; set; }
        public virtual ICollection<Disciplina> Disciplinas { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<Pergunta> Perguntas { get; set; }
        public virtual ICollection<Resposta> Respostas { get; set; }
        public virtual ICollection<Serie> Series { get; set; }
    }
}