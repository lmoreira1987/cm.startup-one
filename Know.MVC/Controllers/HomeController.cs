using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Know.MVC.Util;
using Know.MVC.Models;
using Know.MVC.Data;

namespace Know.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult School()
        {
            return View();
        }

        public ActionResult SchoolRegister()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SchoolRegister(string name, string email, string password)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                var erro = "Foram encontradas as seguintes inconsistências: <br><br>";
                erro += "<ul>";
                erro += string.IsNullOrEmpty(name) ? "<li>Digite o Nome</li>" : String.Empty;
                erro += string.IsNullOrEmpty(email) ? "<li>Digite o E-mail</li>" : String.Empty;
                erro += string.IsNullOrEmpty(password) ? "<li>Digite a Senha</li>" : String.Empty;
                erro += "</ul>";

                return Json(erro, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Criptografia.Criptografia c = new Criptografia.Criptografia();

                Usuario usuario = new Usuario();
                usuario.Nome = name;
                usuario.Email = email;
                usuario.Senha = c.Criptografar(password);
                usuario.DataCriacao = DateTime.Now;
                usuario.Ativo = true;

                Escola escola = new Escola();
                escola.IdPlano = 1; //Pegar o valor que será criptografado via querystring e descriptografar para gravar
                escola.DataCriacao = DateTime.Now;
                escola.Ativo = true;
                escola.Usuario = usuario;

                UsuarioPerfil usuarioPerfil = new UsuarioPerfil();
                usuarioPerfil.IdPerfil = 4;
                usuario.UsuarioPerfils.Add(usuarioPerfil);

                LoginData escolaData = new LoginData();
                escolaData.InserirEscola(escola);

                Session["User"] = usuario;

                return Json("success", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult SchoolRegisterSuccessful()
        {
            return View();
        }        

        public ActionResult Student()
        {
            SerieData studentData = new SerieData();

            return View(studentData.SelecionarSeries());
        }

        [HttpPost]
        public JsonResult RegisterStudent(string name, string email, string serie, string password)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(serie) || string.IsNullOrEmpty(password))
            {
                var erro = "Foram encontradas as seguintes inconsistências: <br><br>";
                erro += "<ul>";
                erro += string.IsNullOrEmpty(name) ? "<li>Digite o Nome</li>" : String.Empty;
                erro += string.IsNullOrEmpty(email) ? "<li>Digite o E-mail</li>" : String.Empty;
                erro += string.IsNullOrEmpty(serie) ? "<li>Selecione a Série</li>" : String.Empty;
                erro += string.IsNullOrEmpty(password) ? "<li>Digite a Senha</li>" : String.Empty;
                erro += "</ul>";

                return Json(erro, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Criptografia.Criptografia c = new Criptografia.Criptografia();

                // Inserir foto fake
                Foto foto = new Foto();
                foto.UrlFoto = "/content/template-admin/images/pictures/profile/profile.jpg";
                foto.Descricao = "Sem foto";
                foto.DataCriacao = DateTime.Now;
                foto.Ativo = true;

                Usuario usuario = new Usuario();
                usuario.Nome = name;
                usuario.Email = email;
                usuario.Senha = c.Criptografar(password);
                usuario.DataCriacao = DateTime.Now;
                usuario.Ativo = true;
                usuario.Foto = foto;

                Aluno aluno = new Aluno();
                aluno.IdSerie = Convert.ToInt64(serie);
                aluno.DataCriacao = DateTime.Now;
                aluno.Ativo = true;
                aluno.Usuario = usuario;

                UsuarioPerfil usuarioPerfil = new UsuarioPerfil();
                usuarioPerfil.IdPerfil = 2;
                usuario.UsuarioPerfils.Add(usuarioPerfil);

                LoginData alunoData = new LoginData();
                alunoData.InserirAluno(aluno);

                Session["User"] = usuario;

                return Json("success", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Signin(string email, string password)
        {
            UtilCriptografia criptografia = new UtilCriptografia();
            LoginData loginData = new LoginData();

            if (String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password) || String.IsNullOrWhiteSpace(email) || String.IsNullOrWhiteSpace(password))
                return Json("error", JsonRequestBehavior.AllowGet);

            Session["User"] = null;

            Usuario usuario = new Usuario();
            usuario = loginData.SelecionarUsuario(email, criptografia.Criptografar(password));

            //((List<Usuario>)System.Web.HttpContext.Current.Application["Users"]).Add(usuario);

            if (usuario != null)
            {
                Session["User"] = usuario;

                var validacao = "";
                validacao = loginData.ValidarUsuario(usuario.Id);

                return Json(validacao, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Logout()
        {
            List<Usuario> usuarios = new List<Usuario>();
            Usuario usuario = new Usuario();
            
            usuario = (Usuario)Session["User"];
            usuarios = ((List<Usuario>)System.Web.HttpContext.Current.Application["Users"]);

            usuarios.Remove(usuarios.Where(u=>u.Id == usuario.Id).FirstOrDefault());

            Session["User"] = null;

            return Json(JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}