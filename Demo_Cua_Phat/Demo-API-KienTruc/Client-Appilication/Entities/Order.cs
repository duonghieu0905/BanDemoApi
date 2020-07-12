using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public double TotalPrice { get; set; }
        public int StaffId { get; set; }
        public int? CustomerId { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
