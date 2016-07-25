using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpresoraFiscal
{
    internal abstract class FiscalPrinter
    {
        public VmaxCom.VmaxComClass ObjVmax;


        public virtual PrinterResponses OpenFiscalReceipt(Invoice invoice, uint numOfCopies)
        {

            var response = numOfCopies > 0 ? (PrinterResponses)ObjVmax.AbrirCFC(numOfCopies, invoice.InvoiceType, invoice.LogoNumber, invoice.Subsidiary, invoice.CashNumber,
                invoice.Ncf, invoice.CompanyName, invoice.Rnc, invoice.NcfReference) : (PrinterResponses)ObjVmax.AbrirCF(invoice.InvoiceType, invoice.LogoNumber, invoice.Subsidiary, invoice.CashNumber,
                invoice.Ncf, invoice.CompanyName, invoice.Rnc, invoice.NcfReference);
            return response == PrinterResponses.Success || response == (PrinterResponses)256 ? PrinterResponses.Success : PrinterResponses.OpeningFiscalReceiptError;
        }

        public PrinterResponses CloseFiscalReceipt()
        {
            var response = (PrinterResponses)ObjVmax.CerrarCF();
            return response == PrinterResponses.Success || response == (PrinterResponses)256 ? PrinterResponses.Success : PrinterResponses.ClosingFiscalReceiptError;
        }

        public virtual void FeedPaper(ushort quantity)
        {
            ObjVmax.AvanzarPapel(quantity);
        }

        public virtual PrinterResponses CancelFiscalReceipt()
        {
            var response = (PrinterResponses)ObjVmax.CancelarCF();
            return response == PrinterResponses.Success || response == (PrinterResponses)256 ?
                PrinterResponses.Success : PrinterResponses.CancellingFiscalReceiptError;

            ;

        }

        public PrinterResponses AddInvoiceComments(string[] comments)
        {
            var response = PrinterResponses.Success;

            foreach (var commnent in comments.Where(a => a != null))
            {
                response = (PrinterResponses)ObjVmax.LineaComentario(commnent);
                if (response != PrinterResponses.Success) break;

            }


            return response == PrinterResponses.Success || response == (PrinterResponses)256 ? PrinterResponses.Success : PrinterResponses.AddingCommentsError;
        }
        public virtual uint CutPaper()
        {
            var response = ObjVmax.CerrarDNF_2(1);

            return response;
        }

        public PrinterResponses AddItems(IEnumerable<Item> items)
        {
            var response = PrinterResponses.Success;
            foreach (var item in from item in items let t = item.Quantity * 100 let o = (uint)(item.Price * 100) let io = (ushort)(item.Rate * 100) select item)
            {

                response = (PrinterResponses)ObjVmax.ItemCF((uint)item.Type, item.AditionalDescriptions != null && item.AditionalDescriptions.Any() ?
                    item.AditionalDescriptions[0] : string.Empty, item.AditionalDescriptions != null && item.AditionalDescriptions.Count() > 1 ?
                        item.AditionalDescriptions[1] : string.Empty,
                    item.AditionalDescriptions != null && item.AditionalDescriptions.Count() > 2 ? item.AditionalDescriptions[2] : string.Empty,
                    item.AditionalDescriptions != null && item.AditionalDescriptions.Count() > 3 ? item.AditionalDescriptions[3] : string.Empty,
                    item.AditionalDescriptions != null && item.AditionalDescriptions.Count() > 4 ? item.AditionalDescriptions[4] : string.Empty,
                    item.AditionalDescriptions != null && item.AditionalDescriptions.Count() > 5 ? item.AditionalDescriptions[5] : string.Empty,
                    item.AditionalDescriptions != null && item.AditionalDescriptions.Count() > 6 ? item.AditionalDescriptions[6] : string.Empty,
                    item.AditionalDescriptions != null && item.AditionalDescriptions.Count() > 7 ? item.AditionalDescriptions[7] : string.Empty,
                    item.AditionalDescriptions != null && item.AditionalDescriptions.Count() > 8 ? item.AditionalDescriptions[8] : string.Empty,
                    item.Description, item.Quantity * 100, (uint)(item.Price * 100),
                    (ushort)(item.Rate * 100));
                if (response != PrinterResponses.Success || response == (PrinterResponses)256) break;
            }
            return response == PrinterResponses.Success || response == (PrinterResponses)256 ? PrinterResponses.Success : PrinterResponses.AddingItemsError;
        }

        public PrinterResponses AddPayments(IEnumerable<Payment> payments)
        {
            var response = PrinterResponses.Success;
            if (payments == null)
                response = (PrinterResponses)ObjVmax.PagoCF(0, 1, ObjVmax.SubtotalParcial, "", "", "");
            else
                foreach (var payment in payments)
                {

                    response = (PrinterResponses)ObjVmax.PagoCF((uint)payment.PaymentType, (ushort)payment.PaymentMethod, (uint)(payment.Value * 100),
                         payment.AditionalDescriptions != null && payment.AditionalDescriptions.Any() ? payment.AditionalDescriptions[0] : string.Empty,
                           payment.AditionalDescriptions != null && payment.AditionalDescriptions.Count() > 1 ? payment.AditionalDescriptions[1] : string.Empty,
                          payment.AditionalDescriptions != null && payment.AditionalDescriptions.Count() > 2 ? payment.AditionalDescriptions[2] : string.Empty);
                    if (response != PrinterResponses.Success || response == (PrinterResponses)256) break;
                }
            return response == PrinterResponses.Success || response == (PrinterResponses)256 ? PrinterResponses.Success : PrinterResponses.AddingPaymentsError;
        }

        public PrinterResponses GetSubTotal()
        {
            var response = (PrinterResponses)ObjVmax.SubtotalCF();
            return response == PrinterResponses.Success || response == (PrinterResponses)256 ? PrinterResponses.Success : PrinterResponses.GettingSubtotalError;

        }

        public virtual PrinterResponses GenerateReportZ(uint tipo)
        {
            var response = (PrinterResponses)ObjVmax.ReporteZ(tipo);
            return response;
        }

        public virtual PrinterResponses GenerateReportX()
        {
            var response = (PrinterResponses)ObjVmax.ReporteX();
            return response;
        }

        public virtual PrinterResponses PrinteLastFiscalReceipt()
        {
            var response = (PrinterResponses)ObjVmax.UltimoCF();
            return response;
        }
        public virtual PrinterResponses OpenNoFiscalReceipt()
        {
            var response = (PrinterResponses)ObjVmax.AbrirDNF();
            return response == PrinterResponses.Success || response == (PrinterResponses)256
                ? PrinterResponses.Success
                : PrinterResponses.OpeningNoFiscalReceiptError;
        }
        public virtual PrinterResponses CloseNoFiscalReceipt()
        {
            var response = (PrinterResponses)ObjVmax.CerrarDNF_2(1);
            return response == PrinterResponses.Success || response == (PrinterResponses)256
                ? PrinterResponses.Success
                : PrinterResponses.ClosingNoFiscalReceiptError;
        }
        public virtual PrinterResponses PrintLineNoFiscalReceipt(IEnumerable<string> lines)
        {
            var response = PrinterResponses.Success;
            foreach (var line in lines)
            {
                response = (PrinterResponses)ObjVmax.LineaDNF(line);
                if (response != PrinterResponses.Success || response == (PrinterResponses)256) break;
            }

            return response == PrinterResponses.Success || response == (PrinterResponses)256
                ? PrinterResponses.Success
                : PrinterResponses.OpeningNoFiscalLineError;
        }
        public virtual void GenerateClosureZ(int tipo, string from, string to, int reportType)
        {
            if (reportType == 1)
                ObjVmax.INFCierreZPorFecha((ushort)tipo, from, to);
            else
                ObjVmax.INFCierreZPorCierreZ((uint)tipo, ushort.Parse(from), ushort.Parse(to));

        }

        public abstract PrinterResponses Print(Invoice invoice, uint numOfCopies);
        public abstract PrinterResponses PrintNoFiscalReceipt(IEnumerable<string> lines);


    }
}
