using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataObjects.Models.PivotGrid;
using DevExpress.Utils;
using DevExpress.Web.Mvc;
using DevExpress.XtraPivotGrid;
using PandoraWeb.Models.PivotGrid;

namespace PandoraWeb.Models.BusinessIntelligence
{
    public class BusinessIntelligenceModel
    {
        public BusinessIntelligenceModel()
        {
            PivotGridExportOptions = new PivotGridExportOptionsModel();
            PivotGridSettings=  new PivotGridSettings();
        }
        public PivotGridExportOptionsModel PivotGridExportOptions { get; set; }
        public PivotGridSettings PivotGridSettings { get; set; }
        public IEnumerable<object> BindData { get; set; }
    }
}