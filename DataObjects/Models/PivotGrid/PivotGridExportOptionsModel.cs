using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects.Models.PivotGrid
{
    public enum ExportFormats { ExcelDataAware, Pdf, Excel, Mht, Rtf, Text, Html }

    public class PivotGridExportOptionsModel
    {
        public PivotGridExportOptionsModel()
        {
            ExportOptions = new PivotGridExportOptions();
            DataAwareOptions = new PivotGridDataAwareOptions();
        }

        public ExportFormats ExportFormat { get; set; }
        public PivotGridExportOptions ExportOptions { get; set; }
        public PivotGridDataAwareOptions DataAwareOptions { get; set; }
    }
}
