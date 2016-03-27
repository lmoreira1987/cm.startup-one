using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Know.MVC.Data;
using Know.MVC.Models;

namespace Know.MVC.Controllers
{
    public class MenuController : Controller
    {
        //
        // GET: /Menu/
        public ActionResult _Menu()
        {
            MenuData menuData = new MenuData();
            var menus = menuData.PreencherMenu((Usuario)Session["User"]);

            return PartialView(menus);
        }
	}
}