﻿using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DevExpress.Export;
using DevExpress.Utils;
using DevExpress.Web.ASPxPivotGrid;
using DevExpress.Web.Mvc;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPrinting;

namespace DevExpress.Web.Demos
{
    public class PivotGridDataOutputDemosHelper
    {
        static PivotGridSettings exportPivotGridSettings;
        static PivotGridSettings dataAwarePivotGridSettings;

        public static PivotGridSettings ExportPivotGridSettings
        {
            get
            {
                if (exportPivotGridSettings == null)
                    exportPivotGridSettings = CreatePivotGridSettings();
                return exportPivotGridSettings;
            }
        }
        public static PivotGridSettings DataAwarePivotGridSettings
        {
            get
            {
                if (dataAwarePivotGridSettings == null)
                    dataAwarePivotGridSettings = CreateDataAwarePivotGridSettings();
                return dataAwarePivotGridSettings;
            }
        }

        public static PivotGridSettings GetPivotGridExportSettings(PivotGridExportWYSIWYGDemoOptions options)
        {
            PivotGridSettings exportSettings = ExportPivotGridSettings;
            exportSettings.SettingsExport.OptionsPrint.PrintHeadersOnEveryPage = options.PrintHeadersOnEveryPage;
            exportSettings.SettingsExport.OptionsPrint.PrintFilterHeaders = ConvertToDefaultBoolean(options.PrintFilterHeaders);
            exportSettings.SettingsExport.OptionsPrint.PrintColumnHeaders = ConvertToDefaultBoolean(options.PrintColumnHeaders);
            exportSettings.SettingsExport.OptionsPrint.PrintRowHeaders = ConvertToDefaultBoolean(options.PrintRowHeaders);
            exportSettings.SettingsExport.OptionsPrint.PrintDataHeaders = ConvertToDefaultBoolean(options.PrintDataHeaders);
            return exportSettings;
        }
        static PivotGridSettings CreatePivotGridSettingsBase()
        {
            PivotGridSettings settings = new PivotGridSettings();
            settings.Name = "pivotGrid";
            settings.CallbackRouteValues = new { Controller = "DataOutput", Action = "ExportPartial" };
            settings.Width = Unit.Percentage(100);
            settings.OptionsView.HorizontalScrollBarMode = ScrollBarMode.Auto;
            return settings;
        }
        static PivotGridSettings CreatePivotGridSettings()
        {
            PivotGridSettings settings = CreatePivotGridSettingsBase();

            settings.Fields.Add(field => {
                field.Area = PivotArea.FilterArea;
                field.AreaIndex = 0;
                field.Caption = "Product";
                field.FieldName = "ProductName";
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.RowArea;
                field.AreaIndex = 0;
                field.Caption = "Customer";
                field.FieldName = "CompanyName";
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.ColumnArea;
                field.AreaIndex = 0;
                field.Caption = "Year";
                field.FieldName = "OrderDate";
                field.GroupInterval = PivotGroupInterval.DateYear;
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.DataArea;
                field.AreaIndex = 0;
                field.Caption = "Product Amount";
                field.FieldName = "ProductAmount";
                field.CellFormat.FormatString = "c";
                field.CellFormat.FormatType = FormatType.Custom;
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.FilterArea;
                field.AreaIndex = 1;
                field.Caption = "Quarter";
                field.FieldName = "OrderDate";
                field.GroupInterval = PivotGroupInterval.DateQuarter;
            });

            return settings;
        }
        static PivotGridSettings CreateDataAwarePivotGridSettings()
        {
            PivotGridSettings settings = CreatePivotGridSettingsBase();

            settings.Name = "SalesPivotGrid";
            settings.CallbackRouteValues = new { Controller = "Report", Action = "SalesPivotGridPartial" };

            settings.Width = Unit.Percentage(100);
            settings.Height = Unit.Pixel(600);

            settings.OptionsView.VerticalScrollingMode = PivotScrollingMode.Virtual;
            settings.OptionsView.HorizontalScrollingMode = PivotScrollingMode.Virtual;
            settings.OptionsView.VerticalScrollBarMode = ScrollBarMode.Auto;
            settings.OptionsView.HorizontalScrollBarMode = ScrollBarMode.Auto;
            settings.OptionsView.ShowFilterHeaders = true;

            settings.OptionsPager.RowsPerPage = 25;
            settings.OptionsPager.ColumnsPerPage = 15;
            settings.OptionsPager.Visible = false;
            settings.OptionsFilter.NativeCheckBoxes = false;

            settings.Fields.Add(field => {
                field.Area = PivotArea.RowArea;
                field.FieldName = "SalesPerson";
                field.Caption = "Vendedor";
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.FilterArea;
                field.FieldName = "DocumentType";
                field.Caption = "Tipo";
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.FilterArea;
                field.FieldName = "Area";
                field.Caption = "Area";
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.FilterArea;
                field.FieldName = "DocumentNumber";
                field.Caption = "Documento_";
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.FilterArea;
                field.FieldName = "DocumentDate";
                field.Caption = "Fecha";
            });
            settings.Fields.Add(field =>
            {
                field.ID = "Año";
                field.Area = PivotArea.ColumnArea;
                field.FieldName = "DocumentDate";
                field.Caption = "Año";
                field.UnboundFieldName = "Ano";
                field.GroupInterval = PivotGroupInterval.DateYear;
            });
            settings.Fields.Add(field =>
            {
                field.ID = "Mes";
                field.Area = PivotArea.ColumnArea;
                field.FieldName = "DocumentDate";
                field.Caption = "Mes";
                field.UnboundFieldName = "Mes";
                field.GroupInterval = PivotGroupInterval.DateMonth;
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.FilterArea;
                field.FieldName = "DocumentDueDate";
                field.Caption = "FechaVencimiento";
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.RowArea;
                field.FieldName = "CustomerName";
                field.Caption = "NombreCliente";
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.FilterArea;
                field.FieldName = "TotalColons";
                field.Caption = "Total";
                field.CellFormat.FormatType = FormatType.Numeric;
                field.CellFormat.FormatString = "₡ #,##0.00";
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.FilterArea;
                field.FieldName = "TaxColon";
                field.Caption = "Impuesto";
                field.CellFormat.FormatType = FormatType.Numeric;
                field.CellFormat.FormatString = "₡ #,##0.00";
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.FilterArea;
                field.FieldName = "GrossProfitColons";
                field.Caption = "Utilidad";
                field.CellFormat.FormatType = FormatType.Numeric;
                field.CellFormat.FormatString = "₡ #,##0.00";
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.FilterArea;
                field.FieldName = "PaidAmountColons";
                field.Caption = "Pagado";
                field.CellFormat.FormatType = FormatType.Numeric;
                field.CellFormat.FormatString = "₡ #,##0.00";
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.DataArea;
                field.FieldName = "TotalDollar";
                field.Caption = "Total_";
                field.CellFormat.FormatType = FormatType.Numeric;
                field.CellFormat.FormatString = "$ #,##0.00";
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.DataArea;
                field.FieldName = "TaxDollar";
                field.Caption = "Impuesto_";
                field.CellFormat.FormatType = FormatType.Numeric;
                field.CellFormat.FormatString = "$ #,##0.00";
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.FilterArea;
                field.FieldName = "GrossProfitDollar";
                field.Caption = "Utilidad_";
                field.CellFormat.FormatType = FormatType.Numeric;
                field.CellFormat.FormatString = "$ #,##0.00";
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.FilterArea;
                field.FieldName = "PaidAmountDollar";
                field.Caption = "Pagado_";
                field.CellFormat.FormatType = FormatType.Numeric;
                field.CellFormat.FormatString = "$ #,##0.00";
            });

            return settings;
        }
        static DefaultBoolean ConvertToDefaultBoolean(bool value)
        {
            return value ? DefaultBoolean.True : DefaultBoolean.False;
        }

        static Dictionary<PivotGridExportFormats, PivotGridExportType> exportTypes;
        static Dictionary<PivotGridExportFormats, PivotGridExportType> CreateExportTypes()
        {
            Dictionary<PivotGridExportFormats, PivotGridExportType> types = new Dictionary<PivotGridExportFormats, PivotGridExportType>();
            types.Add(PivotGridExportFormats.Pdf, new PivotGridExportType { Title = "Export to PDF", Method = PivotGridExtension.ExportToPdf });
            types.Add(PivotGridExportFormats.Excel, new PivotGridExportType { Title = "Export to XLSX", ExcelMethod = PivotGridExtension.ExportToXlsx });
            types.Add(PivotGridExportFormats.ExcelDataAware, new PivotGridExportType { Title = "Export to XLSX", ExcelMethod = PivotGridExtension.ExportToXlsx });
            types.Add(PivotGridExportFormats.Mht, new PivotGridExportType { Title = "Export to MHT", Method = PivotGridExtension.ExportToMht });
            types.Add(PivotGridExportFormats.Rtf, new PivotGridExportType { Title = "Export to RTF", Method = PivotGridExtension.ExportToRtf });
            types.Add(PivotGridExportFormats.Text, new PivotGridExportType { Title = "Export to TEXT", Method = PivotGridExtension.ExportToText });
            types.Add(PivotGridExportFormats.Html, new PivotGridExportType { Title = "Export to HTML", Method = PivotGridExtension.ExportToHtml });
            return types;
        }
        public static ActionResult GetExportActionResult(PivotGridExportDemoOptions options, object data)
        {
            if (exportTypes == null)
                exportTypes = CreateExportTypes();

            PivotGridExportFormats format = options.ExportType;
            PivotGridSettings settings = GetPivotGridExportSettings(options.WYSIWYG);
            switch (format)
            {
                case PivotGridExportFormats.Excel:
                    return exportTypes[format].ExcelMethod(settings, data, new XlsxExportOptionsEx() { ExportType = ExportType.WYSIWYG });
                case PivotGridExportFormats.ExcelDataAware:
                    XlsxExportOptionsEx exportOptions = new XlsxExportOptionsEx() { ExportType = ExportType.DataAware };
                    exportOptions.AllowFixedColumnHeaderPanel = exportOptions.AllowFixedColumns = options.DataAware.AllowFixedColumnAndRowArea ? DefaultBoolean.True : DefaultBoolean.False;
                    exportOptions.AllowGrouping = options.DataAware.AllowGrouping ? DefaultBoolean.True : DefaultBoolean.False;
                    exportOptions.RawDataMode = options.DataAware.ExportRawData;
                    exportOptions.TextExportMode = options.DataAware.ExportDisplayText ? TextExportMode.Text : TextExportMode.Value;
                    return exportTypes[format].ExcelMethod(DataAwarePivotGridSettings, data, exportOptions);
                default:
                    return exportTypes[format].Method(settings, data);
            }
        }
        public delegate ActionResult PivotGridExportMethod(PivotGridSettings settings, object dataObject);
        public delegate ActionResult PivotGridDataAwareExportMethod(PivotGridSettings settings, object dataObject, XlsxExportOptions exportOptions);
        public class PivotGridExportType
        {
            public string Title { get; set; }
            public PivotGridExportMethod Method { get; set; }
            public PivotGridDataAwareExportMethod ExcelMethod { get; set; }
        }

        static PivotGridSettings pivotChartIntegrationSettings;
        public static PivotGridSettings PivotChartIntegrationSettings()
        {
            return PivotChartIntegrationSettings(null);
        }
        public static PivotGridSettings PivotChartIntegrationSettings(object options)
        {
            if (pivotChartIntegrationSettings == null)
                pivotChartIntegrationSettings = CreatePivotChartIntegrationSettings();
            if (options != null)
            {
                pivotChartIntegrationSettings.OptionsChartDataSource.ProvideColumnGrandTotals = true;
                pivotChartIntegrationSettings.OptionsChartDataSource.ProvideRowGrandTotals = true;
                pivotChartIntegrationSettings.OptionsChartDataSource.ProvideDataByColumns = true;
            }
            return pivotChartIntegrationSettings;
        }
        static PivotGridSettings CreatePivotChartIntegrationSettings()
        {
            PivotGridSettings pivotGridSettings = new PivotGridSettings();
            pivotGridSettings.Name = "pivotGrid";
            pivotGridSettings.CallbackRouteValues = new { Controller = "DataOutput", Action = "ChartsIntegrationPivotPartial" };
            pivotGridSettings.OptionsChartDataSource.DataProvideMode = PivotChartDataProvideMode.UseCustomSettings;
            pivotGridSettings.OptionsView.ShowFilterHeaders = false;
            pivotGridSettings.OptionsView.HorizontalScrollBarMode = ScrollBarMode.Auto;
            pivotGridSettings.Width = Unit.Percentage(100);

            pivotGridSettings.Fields.Add(field => {
                field.FieldName = "Extended_Price";
                field.Caption = "Extended Price";
                field.Area = PivotArea.DataArea;
                field.AreaIndex = 0;
            });
            pivotGridSettings.Fields.Add(field => {
                field.FieldName = "CategoryName";
                field.Caption = "Category Name";
                field.Area = PivotArea.RowArea;
                field.AreaIndex = 0;
            });
            pivotGridSettings.Fields.Add(field => {
                field.FieldName = "OrderDate";
                field.Caption = "Order Month";
                field.Area = PivotArea.ColumnArea;
                field.AreaIndex = 0;
                field.UnboundFieldName = "fieldOrderDate";
                field.GroupInterval = PivotGroupInterval.DateMonth;
            });
            pivotGridSettings.PreRender = (sender, e) => {
                int selectNumber = 4;
                var field = ((MVCxPivotGrid)sender).Fields["Category Name"];
                object[] values = field.GetUniqueValues();
                List<object> includedValues = new List<object>(values.Length / selectNumber);
                for (int i = 0; i < values.Length; i++)
                {
                    if (i % selectNumber == 0)
                        includedValues.Add(values[i]);
                }
                field.FilterValues.ValuesIncluded = includedValues.ToArray();
            };
            pivotGridSettings.ClientSideEvents.EndCallback = "UpdateChart";
            return pivotGridSettings;
        }
    }
}