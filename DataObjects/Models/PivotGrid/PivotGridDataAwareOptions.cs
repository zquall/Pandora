using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandoraObjects.Models.PivotGrid
{
    public class PivotGridDataAwareOptions
    {
        public PivotGridDataAwareOptions()
        {
            AllowGrouping = true;
            AllowFixedColumnAndRowArea = true;
        }

        public bool AllowGrouping { get; set; }
        public bool AllowFixedColumnAndRowArea { get; set; }
        public bool ExportDisplayText { get; set; }
        public bool ExportRawData { get; set; }
    }
}
