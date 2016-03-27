﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_KnowEntities : DbContext
    {
        public DB_KnowEntities()
            : base("name=DB_KnowEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Aluno> Alunoes { get; set; }
        public virtual DbSet<Bairro> Bairroes { get; set; }
        public virtual DbSet<Cidade> Cidades { get; set; }
        public virtual DbSet<Dificuldade> Dificuldades { get; set; }
        public virtual DbSet<Disciplina> Disciplinas { get; set; }
        public virtual DbSet<Endereco> Enderecoes { get; set; }
        public virtual DbSet<Escola> Escolas { get; set; }
        public virtual DbSet<Estado> Estadoes { get; set; }
        public virtual DbSet<Foto> Fotoes { get; set; }
        public virtual DbSet<Idioma> Idiomas { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Pai> Pais { get; set; }
        public virtual DbSet<Perfil> Perfils { get; set; }
        public virtual DbSet<PerfilAcesso> PerfilAcessoes { get; set; }
        public virtual DbSet<Pergunta> Perguntas { get; set; }
        public virtual DbSet<Plano> Planoes { get; set; }
        public virtual DbSet<Professor> Professors { get; set; }
        public virtual DbSet<ProfessorDisciplina> ProfessorDisciplinas { get; set; }
        public virtual DbSet<Resposta> Respostas { get; set; }
        public virtual DbSet<Serie> Series { get; set; }
        public virtual DbSet<Sexo> Sexoes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioPerfil> UsuarioPerfils { get; set; }
    }
}
