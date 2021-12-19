using DataAccessLayer;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserBL
    {
        private SalesContext db = new SalesContext();

        public string AddEmployee(Employee emp)
        {
            try
            {
                int rowsAffected = 0;

                if (db.Employees.Any(e => e.EmailID == emp.EmailID))
                {
                    return "Email ID already exists";
                }
                else
                {
                    db.Employees.Add(emp);
                    rowsAffected = db.SaveChanges();

                    if (rowsAffected == 0)
                        return "Something went wrong";
                    else
                        return "Registration successful";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public Employee login(string email, string password)
        {
            Employee emp = db.Employees.SingleOrDefault(e => e.EmailID == email && e.Password == password);
            return emp;
        }

        public List<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        public string AddOrder(Order order)
        {
            try
            {
                int rowsAffected = 0;

                db.Orders.Add(order);
                rowsAffected = db.SaveChanges();

                if (rowsAffected == 0)
                    return "Something went wrong";
                else
                    return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
