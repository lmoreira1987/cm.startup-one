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
    
    public partial class UsuarioPerfil
    {
        public long Id { get; set; }
        public long IdUsuario { get; set; }
        public long IdPerfil { get; set; }
    
        public virtual Perfil Perfil { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
