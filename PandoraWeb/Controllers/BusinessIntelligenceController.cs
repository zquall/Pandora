using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Core;
using DataObjects.Models.PivotGrid;
using PandoraWeb.Helpers;
using PandoraWeb.Models.BusinessIntelligence;

namespace PandoraWeb.Controllers
{
    public class BusinessIntelligenceController : Controller
    {
        // GET: BusinessIntelligence
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SalesByEmployeeByDivision()
        {
            var model = new BusinessIntelligenceModel();
            return View(model);
        }

        public ActionResult SalesByEmployeeByDivisionPartial()
        {
            var model = new BusinessIntelligenceModel();
            var service = new ReportSalesService();
            // model.BindData = service.GetSalesByEmployeeByDivision(DateTime.Today.AddMonths(-3), DateTime.Today);
            model.BindData = new List<object>();
            model.PivotGridSettings = BusinessIntelligenceSettings.SalesByEmployeeByDivisionSettings();

            return PartialView("_PivotGridPartial", model);
        }

        [HttpPost]
        public ActionResult SalesByEmployeeByDivision(PivotGridExportOptionsModel optionsModel)
        {
            var model = new BusinessIntelligenceModel();
            var service = new ReportSalesService();
           // model.BindData = service.GetSalesByEmployeeByDivision(DateTime.Today.AddMonths(-3), DateTime.Today);
            model.BindData = new List<object>();
            model.PivotGridSettings = BusinessIntelligenceSettings.SalesByEmployeeByDivisionSettings();

            //if (Request.Params["ExportTo"] == null)
            //{ // Theme changing
            //    ViewBag.DemoOptions = optionsModel;
            //    return View("SalesByEmployeeByDivision", model);
            //}

            return PivotGridDataExportHelper.ExportActionResult(optionsModel, model);
        }
    }
}