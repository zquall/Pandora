using Core;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PandoraWeb.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SalesByEmployeeByDivision()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult SalesPivotGridPartial()
        {
            var service = new ReportSalesService();
            var model = service.GetSalesByEmployeeByDivision(DateTime.Today.AddMonths(-3), DateTime.Today);
            return PartialView("_SalesPivotGridPartial", model);
        }
    }

}