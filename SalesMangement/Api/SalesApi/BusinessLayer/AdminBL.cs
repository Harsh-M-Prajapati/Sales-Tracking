using DataAccessLayer;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AdminBL
    {
        private SalesContext db = new SalesContext();

        public Admin login(string email, string password)
        {
            Admin ad = db.Admins.SingleOrDefault(a => a.EmailID == email && a.Password == password);
            return ad;
        }

        public List<OrderDetails> GetOrders()
        {
            return db.Database.SqlQuery<OrderDetails>("select e.EmployeeName, e.ContactNo, p.ProductName, p.ProductPrice, o.Quantity, (p.ProductPrice * o.Quantity) as [TotalAmount],o.OrderDate from Orders o Inner Join Employees e on o.EmployeeID = e.EmployeeID Inner Join Products p on o.ProductID = p.ProductID").ToList();
        }
    }
}
