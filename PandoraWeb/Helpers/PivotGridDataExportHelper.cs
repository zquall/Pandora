using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DataObjects.Models.PivotGrid;
using DevExpress.Export;
using DevExpress.Utils;
using DevExpress.Web;
using DevExpress.Web.ASPxPivotGrid;
using DevExpress.Web.Mvc;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPrinting;
using PandoraWeb.Models.BusinessIntelligence;
using PandoraWeb.Models.PivotGrid;

namespace PandoraWeb.Helpers
{
    public class PivotGridDataExportHelper
    {

        public static ActionResult ExportActionResult(PivotGridExportOptionsModel optionsModel, BusinessIntelligenceModel model)
        {
            if (exportTypes == null)
                exportTypes = CreateExportTypes();

            var format = optionsModel.ExportFormat;

            switch (format)
            {
                //case ExportFormats.Excel:
                //    return exportTypes[format].ExcelMethod(model.PivotGridSettings, model.BindData, new XlsxExportOptionsEx() { ExportType = ExportType.WYSIWYG });

                case ExportFormats.Excel:
                    XlsxExportOptionsEx exportOptions = new XlsxExportOptionsEx() { ExportType = ExportType.DataAware };
                    exportOptions.AllowFixedColumnHeaderPanel = exportOptions.AllowFixedColumns = optionsModel.DataAwareOptions.AllowFixedColumnAndRowArea ? DefaultBoolean.True : DefaultBoolean.False;
                    exportOptions.AllowGrouping = optionsModel.DataAwareOptions.AllowGrouping ? DefaultBoolean.True : DefaultBoolean.False;
                    exportOptions.RawDataMode = optionsModel.DataAwareOptions.ExportRawData;
                    exportOptions.TextExportMode = optionsModel.DataAwareOptions.ExportDisplayText ? TextExportMode.Text : TextExportMode.Value;
                    return exportTypes[format].ExcelMethod(model.PivotGridSettings, model.PivotGridData, exportOptions);
                default:
                    return exportTypes[format].Method(model.PivotGridSettings, model.PivotGridData);
            }
        }

        static Dictionary<ExportFormats, PivotGridExportType> exportTypes;
        static Dictionary<ExportFormats, PivotGridExportType> CreateExportTypes()
        {
            Dictionary<ExportFormats, PivotGridExportType> types = new Dictionary<ExportFormats, PivotGridExportType>();
            types.Add(ExportFormats.Pdf, new PivotGridExportType { Title = "Export to PDF", Method = PivotGridExtension.ExportToPdf });
            types.Add(ExportFormats.Excel, new PivotGridExportType { Title = "Export to XLSX", ExcelMethod = PivotGridExtension.ExportToXlsx });
            types.Add(ExportFormats.Mht, new PivotGridExportType { Title = "Export to MHT", Method = PivotGridExtension.ExportToMht });
            types.Add(ExportFormats.Rtf, new PivotGridExportType { Title = "Export to RTF", Method = PivotGridExtension.ExportToRtf });
            types.Add(ExportFormats.Text, new PivotGridExportType { Title = "Export to TEXT", Method = PivotGridExtension.ExportToText });
            types.Add(ExportFormats.Html, new PivotGridExportType { Title = "Export to HTML", Method = PivotGridExtension.ExportToHtml });
            return types;
        }

        public delegate ActionResult PivotGridExportMethod(PivotGridSettings settings, object dataObject);

        public delegate ActionResult PivotGridDataAwareExportMethod(PivotGridSettings settings, object dataObject, XlsxExportOptions exportOptions);
        public class PivotGridExportType
        {
            public string Title { get; set; }
            public PivotGridExportMethod Method { get; set; }
            public PivotGridDataAwareExportMethod ExcelMethod { get; set; }
        }
    }
}