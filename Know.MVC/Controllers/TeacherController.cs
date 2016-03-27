using Know.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Know.MVC.Controllers
{
    public class TeacherController : Controller
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
        // GET: /Teacher/
        public ActionResult Index()
        {
            ValidacaoLogin();

            return View();
        }

        public ActionResult Teacher()
        {
            ValidacaoLogin();

            return View();
        }
	}
}