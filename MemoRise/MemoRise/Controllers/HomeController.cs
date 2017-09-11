using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MemoDAL;
using MemoDAL.EF;

namespace MemoRise.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork(new MemoContext());

        public ActionResult Index()
        {
            unitOfWork.Answers.GetAll();
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
