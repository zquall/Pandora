using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Core;
using PandoraObjects.Models.PivotGrid;
using DevExpress.Web.Mvc;
using PandoraWeb.Helpers;
using PandoraWeb.Models;
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
            var dateStart = new DateTime(lastMonthDate.Year, lastMonthDate.Month, 1);
            var dateEnd = dateStart.AddMonths(1).AddDays(-1);

            model.DateStart = dateStart;
            model.DateEnd = dateEnd;


            var service = new ReportSalesService();
            Session["PivotGridData"] = service.GetSalesByEmployeeByDivision(dateStart, dateEnd);
            Session["PivotGridSettings"] = BusinessIntelligenceSettings.SalesByEmployeeByDivisionSettings();

            return View(model);
        }

        [HttpPost]
        public ActionResult SalesByEmployeeByDivision(BusinessIntelligenceModel model)
        {
            var service = new ReportSalesService();
            Session["PivotGridData"] = service.GetSalesByEmployeeByDivision(model.DateStart, model.DateEnd);

            if (Request.Params["ExportTo"] == null)
            { 
                return View(model);
            }

            model.PivotGridData = (IEnumerable<object>) Session["PivotGridData"];
            model.PivotGridSettings = Session["PivotGridSettings"] as PivotGridSettings;
           
            return PivotGridDataExportHelper.ExportActionResult(model.PivotGridExportOptions, model);
        }

        public ActionResult PivotGridPartial()
        {
            var model = new BusinessIntelligenceModel
            {
                PivotGridData = Session["PivotGridData"] as IEnumerable<object>,
                PivotGridSettings = Session["PivotGridSettings"] as PivotGridSettings
            };
            
            return PartialView("_PivotGridPartial", model);
        }
    }
}