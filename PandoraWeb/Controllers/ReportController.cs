using Core;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Demos;

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


        [HttpGet]
        public ActionResult Export()
        {
            ViewBag.DemoOptions = ViewBag.DemoOptions ?? new PivotGridExportDemoOptions();

            var service = new ReportSalesService();
            var model = service.GetSalesByEmployeeByDivision(DateTime.Today.AddMonths(-3), DateTime.Today);
            return View("_SalesPivotGridPartial", model);
        }
        [HttpPost]
        public ActionResult SalesByEmployeeByDivision(PivotGridExportDemoOptions options)
        {

            var service = new ReportSalesService();
            var model = service.GetSalesByEmployeeByDivision(DateTime.Today.AddMonths(-3), DateTime.Today);
            if (Request.Params["ExportTo"] == null)
            { // Theme changing
                ViewBag.DemoOptions = options;


                return View("_SalesPivotGridPartial", model);
            }

            return PivotGridDataOutputDemosHelper.GetExportActionResult(options, model);
        }
        public ActionResult ExportPartial()
        {
            var service = new ReportSalesService();
            var model = service.GetSalesByEmployeeByDivision(DateTime.Today.AddMonths(-3), DateTime.Today);
            return PartialView("_SalesPivotGridPartial", model);
        }


    }

}