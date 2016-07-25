using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpresoraFiscal
{
    public enum PrinterResponses
    {
        OpeningPortError = 1,
        Success = 0,
        OpeningFiscalReceiptError = 2,
        ClosingFiscalReceiptError = 3,
        AddingItemsError = 4,
        AddingPaymentsError = 5,
        GettingSubtotalError = 6,
        AddingCommentsError = 7,
        GettingPrinterSettingsError = 8,
        GettingReportClosureZError = 9,
        GettingReportZError = 10,
        PrintingLastReciptError = 11,
        CancellingFiscalReceiptError = 12,
        OpeningNoFiscalReceiptError = 13,
        ClosingNoFiscalReceiptError = 14,
        OpeningNoFiscalLineError = 15,
        GettingReportXError = 16





    }
}
