using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OrderDetail
    {
        public string AccessoryId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public string AccessoryName { get; set; }
        public string AccessoryCalculationUnit { get; set; }
        public double AccessoryPrice { get; set; }
    }
}
