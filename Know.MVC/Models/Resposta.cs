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
    
    public partial class Resposta
    {
        public long Id { get; set; }
        public long IdPergunta { get; set; }
        public long IdIdioma { get; set; }
        public string Nome { get; set; }
        public bool Correta { get; set; }
        public string Explicacao { get; set; }
        public System.DateTime DataCriacao { get; set; }
        public Nullable<System.DateTime> DataAtualizacao { get; set; }
        public Nullable<bool> Ativo { get; set; }
    
        public virtual Idioma Idioma { get; set; }
        public virtual Pergunta Pergunta { get; set; }
    }
}
