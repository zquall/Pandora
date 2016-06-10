using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects.Models.PivotGrid
{
    public enum PivotGridExportFormats { ExcelDataAware, Pdf, Excel, Mht, Rtf, Text, Html }

    public class PivotGridExportOptionsModel
    {
        public PivotGridExportOptionsModel()
        {
            ExportOptions = new PivotGridExportOptions();
            DataAwareOptions = new PivotGridDataAwareOptions();
        }

        public PivotGridExportFormats ExportType { get; set; }
        public PivotGridExportOptions ExportOptions { get; set; }
        public PivotGridDataAwareOptions DataAwareOptions { get; set; }
    }
}
