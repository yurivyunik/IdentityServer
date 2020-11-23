using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmsApi.Models;

namespace OmsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize()]

    public class OrderController : ControllerBase
    {
        [HttpPost]
        public bool CreateOrder(Order order)
        {
            return true;
        }

        [HttpPut]
        public bool SubmitOrder(Order order)
        {
            return true;
        }

        [HttpPut]
        public bool RedactOrder(Order order)
        {
            return true;
        }

        [HttpPut]
        public bool ForceOrderRedaction(Order order)
        {
            return true;
        }

        [HttpPut]
        public bool RequestManualSubmission(Order order)
        {
            return true;
        }

        [HttpPut]
        public bool FailOrder(Order order)
        {
            return true;
        }

        [HttpGet]
        public Order SnapshotOrder()
        {
            return new Order();
        }
    }
}
