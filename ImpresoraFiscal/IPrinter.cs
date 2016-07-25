using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpresoraFiscal
{
    interface IPrinter
    {
        uint Connect();
        uint Disconnect();
        PrinterResponses Print(Invoice invoice, uint numOfCopies, bool disconnectOnFinish);
      
    }
}
