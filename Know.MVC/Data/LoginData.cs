using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Know.MVC.Models;

namespace Know.MVC.Data
{
    public class LoginData
    {
        public Usuario SelecionarUsuario(string email, string password)
        {
            using (DB_KnowEntities banco = new DB_KnowEntities())
            {
                return (from u in banco.Usuarios
                        where (u.Ativo && u.Email == email && u.Senha == password)
                        select u).FirstOrDefault();
            }
        }

        public Aluno SelecionarAluno(string email, string password)
        {
            using (DB_KnowEntities banco = new DB_KnowEntities())
            {
                var aluno = (from u in banco.Usuarios
                             join a in banco.Alunoes
                                 on u.Id equals a.IdUsuario
                             where (u.Ativo && a.Ativo && u.Email == email && u.Senha == password)
                             select a).FirstOrDefault();

                return (from u in banco.Usuarios
                        join a in banco.Alunoes
                            on u.Id equals a.IdUsuario
                        where (u.Ativo && a.Ativo && u.Email == email && u.Senha == password)
                        select a).FirstOrDefault();
            }
        }

        public Professor SelecionarProfessor(string email, string password)
        {
            using (DB_KnowEntities banco = new DB_KnowEntities())
            {
                return (from u in banco.Usuarios
                        join p in banco.Professors
                            on u.Id equals p.IdUsuario
                        where (u.Ativo && p.Ativo && u.Email == email && u.Senha == password)
                        select p).FirstOrDefault();
            }
        }

        public Escola SelecionarEscola(string email, string password)
        {
            using (DB_KnowEntities banco = new DB_KnowEntities())
            {
                return (from u in banco.Usuarios
                        join e in banco.Escolas
                            on u.Id equals e.IdUsuario
                        where (u.Ativo && e.Ativo && u.Email == email && u.Senha == password)
                        select e).FirstOrDefault();
            }
        }

        public void InserirAluno(Aluno aluno)
        {
            using (DB_KnowEntities banco = new DB_KnowEntities())
            {
                banco.Alunoes.Add(aluno);
                banco.SaveChanges();
            }
        }

        public void InserirEscola(Escola escola)
        {
            using (DB_KnowEntities banco = new DB_KnowEntities())
            {
                banco.Escolas.Add(escola);
                banco.SaveChanges();
            }
        }



        public string ValidarUsuario(long idUsuario)
        {
            using (DB_KnowEntities banco = new DB_KnowEntities())
            {
                var login = "";

                if(banco.Alunoes.Where(a=>a.IdUsuario == idUsuario).FirstOrDefault() != null)
                {
                    login = "student";
                }
                else if (banco.Professors.Where(p=>p.IdUsuario == idUsuario).FirstOrDefault() != null)
                {
                    login = "teacher";
                }
                else if (banco.Escolas.Where(e => e.IdUsuario == idUsuario).FirstOrDefault() != null)
                {
                    login = "school";
                }
                else
                {
                    login = "error";
                }

                return login;
            }
        }
    }
}