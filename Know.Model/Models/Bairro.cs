//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Know.Model.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bairro
    {
        public Bairro()
        {
            this.Endereco = new HashSet<Endereco>();
        }
    
        public long Id { get; set; }
        public string Nome { get; set; }
        public long IdCidade { get; set; }
        public System.DateTime DataCriacao { get; set; }
        public Nullable<System.DateTime> DataAtualizacao { get; set; }
        public bool Ativo { get; set; }
    
        public virtual Cidade Cidade { get; set; }
        public virtual ICollection<Endereco> Endereco { get; set; }
    }
}