using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpresoraFiscal
{
    public enum PaymentTypes
    {
        Payment = 0,
        PaymentCancellation = 1
    }

    public enum PaymentMethods
    {
        Cash = 1,
        Check = 2,
        CreditCard = 3,
        DebitCard = 4,
        OwnCard = 5,
        Coupon = 6,
        Other1 = 7,
        Other2 = 8,
        Transferencia = 9,
        CreditNote = 10,
        RC00 = 9

    }

    public class Payment
    {
        public PaymentTypes PaymentType { get; set; }
        public PaymentMethods PaymentMethod { get; set; }
        public decimal Value { get; set; }
        public string[] AditionalDescriptions { get; set; }
    }
}
