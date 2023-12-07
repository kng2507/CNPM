using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
   public class ItemInventory
    {
        public ItemInventory(){}

        public string Date { get; set; }
        public int MedicineId { get; set; }
        public int QuantityEntrySlip { get; set; }
        public int QuantityInvoice { get; set; }
    }
}
