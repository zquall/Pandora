﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RentecoEntities : DbContext
    {
        public RentecoEntities()
            : base("name=RentecoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<FAC_FACTURAS> FAC_FACTURAS { get; set; }
        public DbSet<SAP_LoadInvoiceDetail> SAP_LoadInvoiceDetail { get; set; }
        public DbSet<SAP_CreditNoteDetail> SAP_CreditNoteDetail { get; set; }
        public DbSet<SAP_CreditNoteMaster> SAP_CreditNoteMaster { get; set; }
        public DbSet<CXC_RECIBOS> CXC_RECIBOS { get; set; }
        public DbSet<SAP_LoadInvoiceMaster> SAP_LoadInvoiceMaster { get; set; }
    }
}
