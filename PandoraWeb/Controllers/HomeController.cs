using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PandoraWeb.Models;

namespace PandoraWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        [ValidateInput(false)]
        public ActionResult DocumentGridViewPartial()
        {
            var model = new List<DocumentGridViewModel> { new DocumentGridViewModel { Code = string.Empty, Quantity = 1, UnitPrice = 0m } };
            return PartialView("_DataViewPartial", model);
        }
    }
}