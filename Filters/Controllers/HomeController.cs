﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filters.Infrastructure;
using System.Diagnostics;

namespace Filters.Controllers
{
    public class HomeController : Controller
    {
        private Stopwatch timer;

        //[CustomAuth(false)]
        [Authorize(Users = "adam, steve, jacqui,", Roles= "admin")]
        public String Index()
        {
            return "This is the index action on the Home controller";
        }

        //[RangeException]
        [HandleError(ExceptionType = typeof(ArgumentOutOfRangeException), 
            View = "RangeError")]
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
        //[ProfileAction]
        //[ProfileResult]
        //[ProfileAll]
        public string FilterTest()
        {
            return "This is the filtertest action";
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            timer = Stopwatch.StartNew();
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            timer.Stop();
            filterContext.HttpContext.Response.Write(
                string.Format("<div>Total elapsed time: {0}</div>",
                timer.Elapsed.TotalSeconds));
        }
    }
}
