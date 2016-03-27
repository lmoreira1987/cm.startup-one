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
    public class SchoolController : Controller
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
        // GET: /School/
        public ActionResult Index()
        {
            ValidacaoLogin();
            
            
            return View();
        }

        //
        // GET: /School/TeacherRegister
        public ActionResult TeacherRegister()
        {
            ValidacaoLogin();

            List<Professor> professores = new List<Professor>();
            professores = new SchoolData().PreencherTelaProfessores();

            return View(professores);
        }

        public ActionResult AddQuestion()
        {
            ValidacaoLogin();

            SchoolViewModel schoolViewModel = new SchoolViewModel();
            schoolViewModel = new SchoolData().PreencherTelaCadastroPergunta();

            return View(schoolViewModel);
        }

        [HttpPost]
        public JsonResult AddQuestionFinalizar(List<Pergunta> objeto)
        {
            SchoolData schoolData = new SchoolData();
            schoolData.InserirPerguntaRespostas(objeto);

            return Json("success", JsonRequestBehavior.AllowGet);
        }

        public ActionResult ApprovalStudent()
        {
            ValidacaoLogin();

            List<ApprovalStudentViewModel> alunosParaAprovar = new List<ApprovalStudentViewModel>();
            alunosParaAprovar = new SchoolData().PreencherTelaAprovacaoAlunos();

            return View(alunosParaAprovar);
        }

        [HttpPost]
        public JsonResult ApproveDisapproveStudent(long id, string approveDisapprove)
        {
            SchoolData schoolData = new SchoolData();
            string answer = schoolData.UpdateStudentApproval(id, approveDisapprove);

            return Json(answer, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult TeacherRegister(Professor objeto)
        {
            SchoolData schoolData = new SchoolData();
            schoolData.InserirProfessor(objeto);

            return Json(true, JsonRequestBehavior.AllowGet);
        }
	}
}