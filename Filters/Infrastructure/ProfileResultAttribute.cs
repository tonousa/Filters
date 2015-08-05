﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Web.Mvc;

namespace Filters.Infrastructure
{
    public class ProfileResultAttribute : FilterAttribute, IResultFilter
    {
        private Stopwatch timer;

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            timer = Stopwatch.StartNew();
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            timer.Stop();

            filterContext.HttpContext.Response.Write(
                string.Format("<div>Result elapse time: {0}</div>",
                timer.Elapsed.TotalSeconds));
        }
    }
}