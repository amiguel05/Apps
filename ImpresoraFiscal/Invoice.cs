using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpresoraFiscal
{
    public class Invoice
    {
        public uint InvoiceType { get; set; }
        public ushort LogoNumber { get; set; }
        public string Subsidiary { get; set; }
        public string Ncf { get; set; }
        public string Rnc { get; set; }
        public string NcfReference { get; set; }
        public string CompanyName { get; set; }
        public string CashNumber { get; set; }
        public IEnumerable<Payment> Payments { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public string[] Comments { get; set; }

        public Invoice()
        {

        }



    }
}
