using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmsApi.Models;

namespace OmsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize()]
    public class CustomerController : ControllerBase
    {
        [HttpPost]
        public bool CreateCustomer(Customer customer)
        {
            return true;
        }

        [HttpPut]
        public bool RedactCustomer(Customer customer)
        {
            return true;
        }

        [HttpPut]
        public bool ForceCustomerRedaction(Customer customer)
        {
            return true;
        }

        [HttpGet]
        public Customer SnapshotCustomer()
        {
            return new Customer();
        }
    }
}
