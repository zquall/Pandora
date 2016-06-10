using Core;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataObjects.Models.PivotGrid;
using PandoraWeb.Helpers;
using PandoraWeb.Models.Common;

namespace PandoraWeb.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
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
        
        [HttpGet]
        public ActionResult Export()
        {
            ViewBag.DemoOptions = ViewBag.DemoOptions ?? new PivotGridExportOptionsModel();

            var service = new ReportSalesService();
            var model = service.GetSalesByEmployeeByDivision(DateTime.Today.AddMonths(-3), DateTime.Today);
            return View("_SalesPivotGridPartial", model);
        }

        public ActionResult ExportPartial()
        {
            var service = new ReportSalesService();
            var model = service.GetSalesByEmployeeByDivision(DateTime.Today.AddMonths(-3), DateTime.Today);
            return PartialView("_SalesPivotGridPartial", model);
        }


    }

}