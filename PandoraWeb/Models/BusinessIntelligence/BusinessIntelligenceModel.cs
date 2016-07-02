using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandoraObjects.Models.PivotGrid;
using DevExpress.Utils;
using DevExpress.Web.Mvc;
using DevExpress.XtraPivotGrid;
using PandoraWeb.Models.PivotGrid;

namespace PandoraWeb.Models.BusinessIntelligence
{
    public class BusinessIntelligenceModel
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public BusinessIntelligenceModel()
        {
            PivotGridExportOptions = new PivotGridExportOptionsModel();
            PivotGridSettings=  new PivotGridSettings();
        }
        public PivotGridExportOptionsModel PivotGridExportOptions { get; set; }
        public PivotGridSettings PivotGridSettings { get; set; }
        public IEnumerable<object> PivotGridData { get; set; }
    }
}