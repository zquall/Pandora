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
         

            model.PivotGridSettings = BusinessIntelligenceSettings.SalesByEmployeeByDivisionSettings(model);
            model.PivotGridExportOptions = optionsModel;

            if (Request.Params["ExportTo"] == null)
            { 
                return View(model);
            }

            var service = new ReportSalesService();
            model.BindData = service.GetSalesByEmployeeByDivision(optionsModel.DateStart, optionsModel.DateEnd);

            return PivotGridDataExportHelper.ExportActionResult(optionsModel, model);
        }

        public ActionResult SalesByEmployeeByDivisionPartial(BusinessIntelligenceModel model)
        {
            var service = new ReportSalesService();
            model.BindData = service.GetSalesByEmployeeByDivision(model.PivotGridExportOptions.DateStart, model.PivotGridExportOptions.DateEnd);
            // model.BindData = new List<object>();
            model.PivotGridSettings = BusinessIntelligenceSettings.SalesByEmployeeByDivisionSettings(model);

            return PartialView("_PivotGridPartial", model);
        }
    }
}