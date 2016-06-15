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

            var lastMonthDate = DateTime.Today.AddMonths(-1);
            var startDate = new DateTime(lastMonthDate.Year, lastMonthDate.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            model.PivotGridExportOptions.DateStart = startDate;
            model.PivotGridExportOptions.DateEnd = endDate;

            return View(model);
        }

        [HttpPost]
        public ActionResult SalesByEmployeeByDivision(PivotGridExportOptionsModel optionsModel)
        {
            var model = new BusinessIntelligenceModel();
            var service = new ReportSalesService();
            model.BindData = service.GetSalesByEmployeeByDivision(optionsModel.DateStart, optionsModel.DateEnd);

            model.PivotGridSettings = BusinessIntelligenceSettings.SalesByEmployeeByDivisionSettings();
            model.PivotGridExportOptions = optionsModel;

            if (Request.Params["ExportTo"] == null)
            { // Theme changing
                ViewBag.DemoOptions = optionsModel;
                return View(model);
            }

            return PivotGridDataExportHelper.ExportActionResult(optionsModel, model);
        }

        public ActionResult SalesByEmployeeByDivisionPartial()
        {
            var model = new BusinessIntelligenceModel();
            var service = new ReportSalesService();

            var lastMonthDate = DateTime.Today.AddMonths(-1);
            var startDate = new DateTime(lastMonthDate.Year, lastMonthDate.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            
            model.BindData = service.GetSalesByEmployeeByDivision(startDate, endDate);
            // model.BindData = new List<object>();
            model.PivotGridSettings = BusinessIntelligenceSettings.SalesByEmployeeByDivisionSettings();

            return PartialView("_PivotGridPartial", model);
        }
    }
}