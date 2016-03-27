using Know.MVC.Data;
using Know.MVC.Models;
using Know.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Know.MVC.Controllers
{
    public class StudentController : Controller
    {
        private void ValidacaoLogin()
        {
            if (Session["User"] != null)
            {
                ViewBag.User = (Usuario)Session["User"];
            }
            else
            {
                Response.Redirect("~/Home/Index");
            }
        }

        //
        // GET: /Student/
        public ActionResult Index()
        {
            ValidacaoLogin();

            return View();
        }

        public ActionResult WarSelect()
        {
            ValidacaoLogin();

            List<Usuario> usuarios = ((List<Usuario>)System.Web.HttpContext.Current.Application["Users"]);

            WarSelectViewModel warSelectViewModel = new WarSelectViewModel();
            warSelectViewModel = new StudentData().PreencherTelaWarSelect(((Usuario)Session["User"]).Id, usuarios);

            return View(warSelectViewModel);
        }

        public ActionResult WarRoom()
        {
            ValidacaoLogin();

            return View();
        }

        public ActionResult WarRoomStage()
        {
            ValidacaoLogin();

            return View();
        }

        [HttpPost]
        public JsonResult AddUserToWarRoomStage()
        {
            ValidacaoLogin();

            Usuario usuario = new Usuario();
            usuario = (Usuario)Session["User"];

            AddUser(usuario.Id);

            return Json(usuario.Nome, JsonRequestBehavior.AllowGet);
        }

        private void AddUser(long usuarioId)
        {
            bool addUsuario = true;

            foreach (var item in (List<Usuario>)System.Web.HttpContext.Current.Application["Users"])
            {
                if (item.Id == usuarioId)
                {
                    addUsuario = false;
                    break;
                }
            }

            if (addUsuario) 
                ((List<Usuario>)System.Web.HttpContext.Current.Application["Users"]).Add((Usuario)Session["User"]);
        }

        public ActionResult WarSelectNew()
        {
            ValidacaoLogin();

            return View();
        }
	}
}