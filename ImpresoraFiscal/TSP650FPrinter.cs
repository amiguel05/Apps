using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VmaxCom;

namespace ImpresoraFiscal
{
    internal class TSP650FPrinter : FiscalPrinter
    {
        public TSP650FPrinter(VmaxComClass objVmax)
        {
            ObjVmax = objVmax;
        }

        public override PrinterResponses Print(Invoice invoice, uint numOfCopies)
        {
            var response = OpenFiscalReceipt(invoice, numOfCopies);
            if (response != PrinterResponses.Success)
            {
                var cancel = CancelFiscalReceipt();
                return cancel != PrinterResponses.Success ? cancel : response;
            }
            response = AddItems(invoice.Items);
            if (response != PrinterResponses.Success)
            {
                var cancel = CancelFiscalReceipt();
                return cancel != PrinterResponses.Success ? cancel : response;

            }
            response = GetSubTotal();
            if (response != PrinterResponses.Success)
            {
                var cancel = CancelFiscalReceipt();
                return cancel != PrinterResponses.Success ? cancel : response;
            }
            response = AddPayments(invoice.Payments);
            if (response != PrinterResponses.Success)
            {
                var cancel = CancelFiscalReceipt();
                return cancel != PrinterResponses.Success ? cancel : response;
            }

            response = AddInvoiceComments(invoice.Comments);
            if (response != PrinterResponses.Success)
            {
                var cancel = CancelFiscalReceipt();
                return cancel != PrinterResponses.Success ? cancel : response;
            }
            response = CloseFiscalReceipt();
            if (response != PrinterResponses.Success)
            {
                var cancel = CancelFiscalReceipt();
                return cancel != PrinterResponses.Success ? cancel : response;
            }
            CutPaper();


            return response;

        }

        public override PrinterResponses PrintNoFiscalReceipt(IEnumerable<string> lines)
        {
            var response = OpenNoFiscalReceipt();
            if (response != PrinterResponses.Success)
                return response;
            response = PrintLineNoFiscalReceipt(lines);
            if (response != PrinterResponses.Success)
            {
                CloseNoFiscalReceipt();
                return response;
            }
            // AvanzarPapel(15);
            CloseNoFiscalReceipt();


            return response;
        }
    }
}
