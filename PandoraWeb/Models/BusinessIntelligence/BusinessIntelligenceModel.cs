using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Utils;
using DevExpress.Web.Mvc;
using DevExpress.XtraPivotGrid;
using PandoraWeb.Models.PivotGrid;

namespace PandoraWeb.Models.BusinessIntelligence
{
    public class BusinessIntelligenceModel
    {
        public PivotGridSettings PivotGridSettings { get; set; }
        public IEnumerable<object> BindData { get; set; }
    }
}