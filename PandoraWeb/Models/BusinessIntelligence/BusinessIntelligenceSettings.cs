using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Utils;
using DevExpress.Web.Mvc;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraScheduler.iCalendar.Components;
using PandoraWeb.Models.PivotGrid;

namespace PandoraWeb.Models.BusinessIntelligence
{
    public static class BusinessIntelligenceSettings
    {
        public static PivotGridSettings SalesByEmployeeByDivisionSettings()
        {
            PivotGridSettings settings = new PivotGridSettingsBase("BusinessIntelligence", "PivotGridPartial");

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
                field.Caption = "Documento#";
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
                field.Caption = "Total₡";
                field.CellFormat.FormatType = FormatType.Numeric;
                field.CellFormat.FormatString = "₡ #,##0.00";
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.FilterArea;
                field.FieldName = "TaxColon";
                field.Caption = "Impuesto₡";
                field.CellFormat.FormatType = FormatType.Numeric;
                field.CellFormat.FormatString = "₡ #,##0.00";
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.FilterArea;
                field.FieldName = "GrossProfitColons";
                field.Caption = "Utilidad₡";
                field.CellFormat.FormatType = FormatType.Numeric;
                field.CellFormat.FormatString = "₡ #,##0.00";
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.FilterArea;
                field.FieldName = "PaidAmountColons";
                field.Caption = "Pagado₡";
                field.CellFormat.FormatType = FormatType.Numeric;
                field.CellFormat.FormatString = "₡ #,##0.00";
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.FilterArea;
                field.FieldName = "DiscountColons";
                field.Caption = "Descuento₡";
                field.CellFormat.FormatType = FormatType.Numeric;
                field.CellFormat.FormatString = "₡ #,##0.00";
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.DataArea;
                field.FieldName = "TotalDollar";
                field.Caption = "Total$";
                field.CellFormat.FormatType = FormatType.Numeric;
                field.CellFormat.FormatString = "$ #,##0.00";
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.DataArea;
                field.FieldName = "TaxDollar";
                field.Caption = "Impuesto$";
                field.CellFormat.FormatType = FormatType.Numeric;
                field.CellFormat.FormatString = "$ #,##0.00";
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.FilterArea;
                field.FieldName = "GrossProfitDollar";
                field.Caption = "Utilidad$";
                field.CellFormat.FormatType = FormatType.Numeric;
                field.CellFormat.FormatString = "$ #,##0.00";
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.FilterArea;
                field.FieldName = "PaidAmountDollar";
                field.Caption = "Pagado$";
                field.CellFormat.FormatType = FormatType.Numeric;
                field.CellFormat.FormatString = "$ #,##0.00";
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.FilterArea;
                field.FieldName = "DiscountDollar";
                field.Caption = "Descuento$";
                field.CellFormat.FormatType = FormatType.Numeric;
                field.CellFormat.FormatString = "$ #,##0.00";
            });
            return settings;
        }
        
    }
}