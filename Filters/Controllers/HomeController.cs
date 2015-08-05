using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filters.Infrastructure;

namespace Filters.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        [CustomAuth(false)]
        public String Index()
        {
            return "This is the index action on the Home controller";
        }

        //[RangeException]
        [HandleError(ExceptionType = typeof(ArgumentOutOfRangeException), View = "RangeError")]
        public string RangeTest(int id)
        {
            if (id > 100)
            {
                return String.Format("The id value is: {0}", id);
            }
            else
            {
                throw new ArgumentOutOfRangeException("id", id, "");
            }
        }

        //[CustomAction]
        [ProfileAction]
        [ProfileResult]
        public string FilterTest()
        {
            return "This is the filtertest action";
        }
    }
}
