using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core;

namespace PandoraWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //var service = new ReportSalesService();
            //var result = service.GetSalesByEmployeeByDivision(DateTime.Today, DateTime.Today);
            return View();
        }
    }
}