using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Accessory
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public DateTime GoodsReceiptDate { get; set; }
        public int Inventory { get; set; }
        public double Price { get; set; }
        public string WarrantyTime { get; set; }
        public string CalculationUnit { get; set; }
        public string CPU { get; set; }
        public string Cores { get; set; }
        public string Threads { get; set; }
        public string ProcessingSpeed { get; set; }
        public string Size { get; set; }
        public string Socket { get; set; }
        public string Chipset { get; set; }
        public string Memory { get; set; }
        public string Version { get; set; }
        public string Bus { get; set; }
        public string BIT { get; set; }
        public string Power { get; set; }
        public int Status { get; set; }
        public int ProducerId { get; set; }
        public string CategoryId { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
