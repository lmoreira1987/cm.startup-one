using Know.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Know.MVC.Controllers
{
    public class ChatController : Controller
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
        
        public ActionResult Index()
        {
            ValidacaoLogin();

            return View();
        }
	}
}