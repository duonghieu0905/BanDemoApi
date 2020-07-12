using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CustomerDAL
    {
        private readonly ShoppingDBContext db;
        public CustomerDAL()
        {
            db = new ShoppingDBContext();
            db.Configuration.ProxyCreationEnabled = false;
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return db.Customers;
        }
        public bool AddCustomer(Customer customer)
        {
            customer.Points = 0;
            //customer.BirthDate = DateTime.Now;
            var check = db.Customers.FirstOrDefault(x => x.NumberPhone.Equals(customer.NumberPhone));
            if (check == null)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool UpdateCustomer(Customer customer)
        {
            var check = db.Customers.FirstOrDefault(x => x.NumberPhone.Equals(customer.NumberPhone));
            if (check != null)
            {
                check.Address = customer.Address;
                check.BirthDate = customer.BirthDate;
                check.Email = customer.Email;
                check.Name = customer.Name;
                check.IdentifyNumber = customer.IdentifyNumber;
                db.SaveChanges();
                return true;
            }
            return false;

        }
    }
}
