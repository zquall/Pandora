//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Derminator
{
    using System;
    using System.Collections.Generic;
    
    public partial class FAC_FACTURAS
    {
        public string CIA_Codigo { get; set; }
        public double FAC_Numero { get; set; }
        public string FAC_Tipo { get; set; }
        public Nullable<double> CON_Numero { get; set; }
        public Nullable<double> SAL_Numero { get; set; }
        public string PRO_Numero { get; set; }
        public short FAC_EsDeCredito { get; set; }
        public System.DateTime FAC_Fecha { get; set; }
        public Nullable<System.DateTime> FAC_FechaVencimiento { get; set; }
        public string FAC_Orden_Compra { get; set; }
        public string FAC_FormaPago { get; set; }
        public string FAC_Documento { get; set; }
        public double TRA_Numero { get; set; }
        public string DEV_Numero { get; set; }
        public string BOD_Bodega { get; set; }
        public string CLI_Cliente { get; set; }
        public string CLI_Nombre { get; set; }
        public string VEN_Vendedor { get; set; }
        public double VEN_Comision { get; set; }
        public string PRO_Proyecto { get; set; }
        public double FAC_Costo { get; set; }
        public string FAC_Observacion { get; set; }
        public decimal FAC_Gravadas { get; set; }
        public decimal FAC_Exentas { get; set; }
        public decimal FAC_SubTotal { get; set; }
        public decimal FAC_Porcentaje_Descuento { get; set; }
        public decimal FAC_Descuento { get; set; }
        public Nullable<decimal> FAC_Impuesto { get; set; }
        public decimal FAC_Total { get; set; }
        public decimal FAC_Saldo { get; set; }
        public string FAC_Estado { get; set; }
        public double FAC_Transporte { get; set; }
        public double FAC_TipoCambio { get; set; }
        public string FAC_Moneda { get; set; }
        public short FAC_Contabilizado { get; set; }
        public string FAC_Refactura { get; set; }
        public short FAC_CierreFiscal { get; set; }
        public Nullable<double> FAC_facturaAnterior { get; set; }
        public Nullable<double> FAC_MontoNC { get; set; }
        public double FAC_Descuento_ProntoPago { get; set; }
        public double FAC_Costo_Colon { get; set; }
        public byte[] timestamp { get; set; }
        public string USR_Usuario_Modificacion { get; set; }
        public Nullable<System.DateTime> USR_Fecha_Modificacion { get; set; }
        public string USR_Usuario_Inclusion { get; set; }
        public Nullable<System.DateTime> USR_Fecha_Inclusion { get; set; }
        public string BNC_Banco { get; set; }
        public string MOV_Tipo { get; set; }
        public Nullable<double> Mov_Numero { get; set; }
        public string FAC_HORA { get; set; }
        public Nullable<int> NumberOfImpressions { get; set; }
        public Nullable<int> MigradaSAP { get; set; }
        public byte IsFirstInvoice { get; set; }
    }
}