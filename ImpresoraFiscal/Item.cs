using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpresoraFiscal
{
    public enum ItemTypes
    {
        SalesItem = 0,
        SalesItemCancellation = 1,
        DiscountPerItem = 2,
        SurchargePerItem = 3,
        ReturnItem = 4,
        ReturnItemCancellation = 5

    }

    public class Item
    {
        public ItemTypes Type { get; set; }
        public string Description { get; set; }
        public uint Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Rate { get; set; }
        public string[] AditionalDescriptions { get; set; }
    }
}
