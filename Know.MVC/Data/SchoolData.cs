using Know.MVC.Models;
using Know.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Know.MVC.Data
{
    public class SchoolData
    {
        public SchoolViewModel PreencherTelaCadastroPergunta()
        {
            using (DB_KnowEntities banco = new DB_KnowEntities())
            {
                SchoolViewModel s = new SchoolViewModel();
                s.Idiomas = new List<Idioma>();
                s.Disciplinas = new List<Disciplina>();
                s.Series = new List<Serie>();
                s.Dificuldades = new List<Dificuldade>();
                s.Perguntas = new List<Pergunta>();

                s.Idiomas.AddRange(banco.Idiomas.ToList());
                s.Disciplinas.AddRange(banco.Disciplinas.ToList());
                s.Series.AddRange(banco.Series.ToList());
                s.Dificuldades.AddRange(banco.Dificuldades.ToList());
                s.Perguntas.AddRange(banco.Perguntas.ToList());

                foreach (var item in s.Perguntas)
                {
                    item.Respostas = new List<Resposta>();
                    var respostas = banco.Respostas.Where(r => r.IdPergunta == item.Id).ToList();
                    foreach (var resp in respostas)
                    {
                        item.Respostas.Remove(resp);
                        item.Respostas.Add(resp);
                    }
                }

                return s;
            }
        }

        public void InserirPerguntaRespostas(List<Pergunta> objeto)
        {
            var codigoGrupo = UltimoCodigoGrupo();
            foreach (var item in objeto)
            {
                item.CodigoGrupo = codigoGrupo;
            }

            using (DB_KnowEntities banco = new DB_KnowEntities())
            {
                banco.Perguntas.AddRange(objeto);
                banco.SaveChanges();
            }
        }

        private long UltimoCodigoGrupo()
        {
            using (DB_KnowEntities banco = new DB_KnowEntities())
            {
                return banco.Perguntas.Count() == 0 ? 1 : banco.Perguntas.OrderByDescending(o => o.Id).FirstOrDefault().CodigoGrupo + 1;
            }
        }

        public List<ApprovalStudentViewModel> PreencherTelaAprovacaoAlunos()
        {
            using (DB_KnowEntities banco = new DB_KnowEntities())
            {
                return (from u in banco.Usuarios
                        join a in banco.Alunoes
                            on u.Id equals a.IdUsuario
                        join f in banco.Fotoes
                            on u.IdFoto equals f.Id
                        join s in banco.Series
                            on a.IdSerie equals s.Id
                        where (a.AprovadoEscola == null)
                        && (a.Ativo == true)
                        && (f.Ativo == true || f == null)
                        && (s.Ativo == true || s == null)
                        select new ApprovalStudentViewModel
                        {
                            Id = a.Id,
                            Foto = f.UrlFoto,
                            Nome = u.Nome,
                            Serie = s.Nome,
                            DataCriacao = a.DataCriacao
                        }).ToList();


            }
        }

        public string UpdateStudentApproval(long id, string approveDisapprove)
        {
            using (DB_KnowEntities banco = new DB_KnowEntities())
            {
                Aluno aluno = new Aluno();
                aluno = banco.Alunoes.Find(id);
                aluno.AprovadoEscola = approveDisapprove == "approve" ? true : false;
                aluno.DataAprovadoEscola = DateTime.Now;

                banco.SaveChanges();
            }

            return approveDisapprove;
        }

        public void InserirProfessor(Professor objeto)
        {
            using (DB_KnowEntities banco = new DB_KnowEntities())
            {
                Foto foto = new Foto();
                foto.UrlFoto = "/content/template-admin/images/pictures/profile/profile.jpg";
                foto.Descricao = "Sem foto";
                foto.DataCriacao = DateTime.Now;
                foto.Ativo = true;

                Criptografia.Criptografia c = new Criptografia.Criptografia();
                objeto.Usuario.Senha = c.Criptografar(objeto.Usuario.Documento); // Senha padrão
                objeto.Usuario.Foto = foto;

                UsuarioPerfil usuarioPerfil = new UsuarioPerfil();
                usuarioPerfil.IdPerfil = 3;
                objeto.Usuario.UsuarioPerfils.Add(usuarioPerfil);

                banco.Professors.Add(objeto);
                banco.SaveChanges();
            }
        }

        public List<Professor> PreencherTelaProfessores()
        {
            using (DB_KnowEntities banco = new DB_KnowEntities())
            {
                var professores = (from u in banco.Usuarios
                            join p in banco.Professors
                                on u.Id equals p.IdUsuario
                            where (p.Ativo == true && u.Ativo == true)
                            select p
                    ).ToList();

                foreach (var item in professores)
                {
                    item.Usuario = new Usuario();
                    item.Usuario = banco.Usuarios.Find(item.IdUsuario);
                }

                return professores;
            }
        }
    }
}