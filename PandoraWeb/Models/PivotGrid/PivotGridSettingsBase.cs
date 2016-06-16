using System;
using System.Web.UI.WebControls;
using DevExpress.Web;
using DevExpress.Web.ASPxPivotGrid;
using DevExpress.Web.Mvc;
using PandoraWeb.Models.BusinessIntelligence;

namespace PandoraWeb.Models.PivotGrid
{
    public sealed class PivotGridSettingsBase : PivotGridSettings
    {
        public PivotGridSettingsBase(string controller, string action)
        {
            Name = "PandoraPivotGrid";
            CallbackRouteValues = new { Controller = controller, Action = action };

            Width = Unit.Percentage(100);
            Height = Unit.Pixel(600);

            OptionsView.VerticalScrollingMode = PivotScrollingMode.Virtual;
            OptionsView.HorizontalScrollingMode = PivotScrollingMode.Virtual;
            OptionsView.VerticalScrollBarMode = ScrollBarMode.Auto;
            OptionsView.HorizontalScrollBarMode = ScrollBarMode.Auto;
            OptionsView.ShowFilterHeaders = true;

            OptionsPager.RowsPerPage = 25;
            OptionsPager.ColumnsPerPage = 15;
            OptionsPager.Visible = false;
            OptionsFilter.NativeCheckBoxes = false;
        }
    }
}
