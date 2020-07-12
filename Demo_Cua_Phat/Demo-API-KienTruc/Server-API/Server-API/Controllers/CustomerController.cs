using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server_API.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly CustomerDAL customerDAL;
        public CustomerController()
        {
            customerDAL = new CustomerDAL();
        }
        [Route("api/Customer/GetCustomers")]
        public IHttpActionResult GetCustomers()
        {
            return Json(customerDAL.GetCustomers());
        }
        [Route("api/Customer/AddCustomer")]
        public IHttpActionResult AddCustomer(Customer customer)
        {
            return Json(customerDAL.AddCustomer(customer));
        }
        [Route("api/Customer/UpdateCustomer")]
        public IHttpActionResult UpdateCustomer(Customer customer)
        {
            return Json(customerDAL.UpdateCustomer(customer));
        }

    }
}
