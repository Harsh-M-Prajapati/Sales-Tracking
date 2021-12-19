using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class OrderDetails
    {
        public string EmployeeName { get; set; }

        public string ContactNo { get; set; }

        public string ProductName { get; set; }

        public string ProductPrice { get; set; }

        public int Quantity { get; set; }

        public string OrderDate { get; set; }

        public int TotalAmount { get; set; }

    }
}
