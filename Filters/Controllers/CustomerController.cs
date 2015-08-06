using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filters.Infrastructure;

namespace Filters.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/
        [SimpleMessage(message="A", Order=2)]
        [SimpleMessage(message="B", Order=1)]
        public string Index()
        {
            return "This is the customer controller";
        }

    }
}
