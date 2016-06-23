using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataObjects.Customer;
using DataObjects.Item;
using NLog;

namespace Derminator
{
    public partial class Form : DevExpress.XtraEditors.XtraForm
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public static string PhitosAddress { get; set; }

        public static int MigratedFlag { get; set; }
    public Form()
        {
            PhitosAddress = "http://pithos.renteco.org/";
            MigratedFlag = 1;

#if DEBUG
            PhitosAddress = "http://dev.pithos.renteco.org/";
            MigratedFlag = 0;
#endif

            InitializeComponent();
        }

        public string FindServer(string serverName)
        {
            // var ipHostInfo = Dns.GetHostEntry(serverName); // `Dns.Resolve()` method is deprecated.
            // var ipAddress = ipHostInfo.AddressList[0];

            var ipAddress = IPAddress.Parse("192.168.1.1");

            var pingSender = new Ping();

            var retry = true;
            while (retry)
            {
                var reply = pingSender.Send(ipAddress, 3000);

                if (reply != null && reply.Status == IPStatus.Success) retry = false;

                logger.Info("...");
                Thread.Sleep(1000);
            }

            return ipAddress.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            logger.Trace("Sample trace message");
            logger.Debug("Sample debug message");
            logger.Info("Sample informational message");
            logger.Warn("Sample warning message");
            logger.Error("Sample error message");
            logger.Fatal("Sample fatal error message");

            // alternatively you can call the Log() method 
            // and pass log level as the parameter.
            logger.Log(LogLevel.Info, "Sample informational message");
        }

        private void Form_Load(object sender, EventArgs e)
        {
            logger.Info("Start System");

            // Task.Run(() =>  LoadPendingInvoices());


            // Sino no marcar y mandar el error por correo
            // REvisar facuturas anuladas;    
            
            LoadLogFile();
        }

        private void LoadPendingInvoices()
        {
            var invoces = new List<CustomerInvoice>();
            var headers = new List<SAP_LoadInvoiceMaster>();
            var details = new List<SAP_LoadInvoiceDetail>();

            logger.Info("Cargando Facturas");
            using (var renteco = new RentecoEntities())
            {
                headers = renteco.SAP_LoadInvoiceMaster.ToList();
                details = renteco.SAP_LoadInvoiceDetail.ToList();
            }
            
            foreach (var header in headers)
            {
                var customerInvoice = new CustomerInvoice
                {
                    SellerCode = header.SalesPersonCode == null ? 0 : (int) header.SalesPersonCode,
                    DiscountPercent = header.DiscountPercent,
                    DocumentId = (int) header.DocNum,
                    InvoiceType = header.DocType,
                    DocumentType = header.U_SCG_TipoDocumento,
                    CustomerCode = header.CardCode,

                    Comments = header.Comments,
                    PostingDate = header.DocDate,
                    DueDate = header.DocDueDate ?? DateTime.Today,
                    DocumentDate = header.TaxDate,
                    DocCurrency = header.DocCurrency,
                    NumAtCard = header.NumAtCard.ToString(CultureInfo.InvariantCulture),
                    HandWritten = header.HandWritten == "tYES",
                    ManualNumber = header.ManualNumber == "tYES"
                };
                
                // Invoice Details
                var invoiceDetails = details.Where(x => x.RecordKey.Equals(header.DocNum)).ToList();

                customerInvoice.ItemDetails = new List<ItemDetail>();
                foreach (var invoiceDetail in invoiceDetails)
                {
                    string itemCode;
                    // Item code detection
                    switch (invoiceDetail.AccountCode)
                    {
                        case "_SYS00000000300":
                            itemCode = "A9999999";
                            break;
                        case "_SYS00000000304":
                            itemCode = "A9999998";
                            break;
                        case "_SYS00000000324":
                            itemCode = "A9999997";
                            break;
                        default:
                            itemCode = "A9999999";
                            break;
                    }


                    customerInvoice.ItemDetails.Add(new ItemDetail
                    {
                        TaxLiable = false,
                        ItemCode = itemCode,
                        TaxCode = invoiceDetail.TaxCode,
                        Currency = invoiceDetail.Currency,
                        Quantity = 1,
                        WarehouseCode = 16,
                        Price = invoiceDetail.LineTotal == null? 0 : Convert.ToDecimal(invoiceDetail.LineTotal.Value),
                        DiscountPercent = invoiceDetail.DiscountPercent
                    });
                }

            invoces.Add(customerInvoice);

            }
            
            SavePendingInvoices(invoces);


            Task.Run(() => LoadPendingCreditNotes());
        }

        private void LoadPendingCreditNotes()
        {
            var creditNotes = new List<CustomerInvoice>();
            var headers = new List<SAP_CreditNoteMaster>();
            var details = new List<SAP_CreditNoteDetail>();

            logger.Info("Cargando Notas de Credito");
            using (var renteco = new RentecoEntities())
            {
                headers = renteco.SAP_CreditNoteMaster.ToList();
                details = renteco.SAP_CreditNoteDetail.ToList();
            }

            foreach (var header in headers)
            {
                var customerInvoice = new CustomerInvoice
                {
                    SellerCode = header.SlpCode == null ? 0 : (int)header.SlpCode,
                    DiscountPercent = header.DiscountPercent,
                    DocumentId = (int)header.DocNum,
                    InvoiceType = header.DocType,
                    DocumentType = header.TipoDocumento,
                    CustomerCode = header.CardCode,

                    Comments = header.Comments,
                    PostingDate = header.DocDate,  // Fecha Contabilizacion
                    DueDate = header.DocDate,      // Fecha Vencimiento
                    DocumentDate = header.TaxDate, // Fecha Documento
                    DocCurrency = header.DocCurrency,
                    NumAtCard = header.NumAtCard.ToString(CultureInfo.InvariantCulture),
                    HandWritten = header.HandWritten == "tYES",
                    ManualNumber = header.ManualNumber == "tYES"
                };

                // Invoice Details
                var invoiceDetails = details.Where(x => x.RecordKey.Equals(header.DocNum)).ToList();

                customerInvoice.ItemDetails = new List<ItemDetail>();
                foreach (var invoiceDetail in invoiceDetails)
                {
                    customerInvoice.ItemDetails.Add(new ItemDetail
                    {
                        TaxLiable = false,
                        ItemCode =  "A9999999",
                        TaxCode = invoiceDetail.TaxCode,
                        Currency = invoiceDetail.Currency,
                        Quantity = 1,
                        WarehouseCode = 16,
                        Price = invoiceDetail.LineTotal == null ? 0 : Convert.ToDecimal(invoiceDetail.LineTotal.Value),
                        DiscountPercent = invoiceDetail.DiscountPercent
                    });
                }

                creditNotes.Add(customerInvoice);

            }

            SavePendingCreditNotes(creditNotes);
        }
        
        private static void SavePendingInvoices(IEnumerable<CustomerInvoice> invoces)
        {
            //SaveInvoiceRunAsync(invoces.First()).Wait();
            foreach (var invoce in invoces)
            {
                SaveInvoiceRunAsync(invoce).Wait();
            }
            logger.Info("Batch Finished!");
        }

        private static void SavePendingCreditNotes(IEnumerable<CustomerInvoice> creditNotes)
        {

            //SaveCreditNoteRunAsync(creditNotes.First()).Wait();
            foreach (var creditNote in creditNotes)
            {
                SaveCreditNoteRunAsync(creditNote).Wait();
            }
            logger.Info("Batch Finished!");
        }

        static async Task SaveInvoiceRunAsync(CustomerInvoice invoce)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(PhitosAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PostAsJsonAsync("api/CustomerInvoice", invoce);
                if (response.IsSuccessStatusCode)
                {
                    MarkInvoiceAsMigrated(invoce.DocumentId);
                }
                else
                {
                    logger.Error("La Factura #{0} dio un Error por parte de SAP y no fue migrada", invoce.DocumentId);
                }
            }
        }

        private static void MarkInvoiceAsMigrated(int invoiceId)
        {
            using (var renteco = new RentecoEntities())
            {
                var documentId = Convert.ToDouble(invoiceId);
                var currentInvoice = renteco.FAC_FACTURAS.FirstOrDefault(x => x.FAC_Numero == documentId);
                if (currentInvoice != null)
                {
                    try
                    {
                        currentInvoice.MigradaSAP = MigratedFlag;
                        
                        renteco.SaveChanges();
                        logger.Info("Factura #{0} Migrada a SAP Correctamente", invoiceId);
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Problema marcando como migrada la factura #{0} {1}", invoiceId, ex.Message);
                    }
                }
                else
                {
                    logger.Error("Factura #{0} No fue posible marcarla como migrada, no se encontro", invoiceId);
                }
            }
        }


        static async Task SaveCreditNoteRunAsync(CustomerInvoice creditNote)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(PhitosAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PostAsJsonAsync("api/CreditNote", creditNote);

                var creditNoteId = creditNote.DocumentId;
                if (response.IsSuccessStatusCode)
                {
                    MarkCreditNoteAsMigrated(creditNoteId);
                }
                else
                {
                    logger.Error("La Nota de Credito #{0} dio un Error por parte de SAP y no fue migrada", creditNoteId);
                }
            }
        }

        private static void MarkCreditNoteAsMigrated(int creditNoteId)
        {
            using (var renteco = new RentecoEntities())
            {
                var documentId = Convert.ToDouble(creditNoteId);
                var currentCreditNote = renteco.CXC_RECIBOS.FirstOrDefault(x => x.CXC_Recibo.Equals(documentId));
                if (currentCreditNote != null)
                {
                    try
                    {
                        currentCreditNote.MigradaSAP = MigratedFlag == 1;

                        renteco.SaveChanges();
                        logger.Info("Nota de Credito #{0} Migrada a SAP Correctamente", creditNoteId);
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Problema marcando como migrada la Nota de Credito #{0} - {1}", creditNoteId, ex.Message);
                    }
                }
                else
                {
                    logger.Error("Nota de Credito #{0} No fue posible marcarla como migrada, no se encontro", creditNoteId);
                }
            }
        }


        private void LoadLogFile()
        {
            using (var reader = File.OpenText("DerminatorLog.txt"))
            {
                Memo.Text = reader.ReadToEnd();
                Memo.SelectionStart = Memo.Text.Length;
                Memo.ScrollToCaret();
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadLogFile();
        }

        private void RunButton_Click(object sender, EventArgs e)
        {

            var serverName = "Servidor";
            logger.Info("Buscando Servidor llamado : " + serverName);
            FindServer(serverName);

            Task.Run(() => LoadPendingInvoices());
            
        }
                   
    }
}
