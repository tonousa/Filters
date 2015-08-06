using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Diagnostics;

namespace Filters.Infrastructure
{
    public class ProfileAllAttribute : ActionFilterAttribute
    {
        public Stopwatch timer;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            timer = Stopwatch.StartNew();
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            timer.Stop();

            filterContext.HttpContext.Response.Write(
                string.Format("<div>Total elapsed time: {0}</div>",
                timer.Elapsed.TotalSeconds));
        }
    }
}