using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System;

namespace PopulationAPI.Exception
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Log.Logger.Error(context.Exception, context.Exception.Message);

            if (context.Exception is FormatException)
            {
                context.Result = new BadRequestResult();
            }
        }
    }
}
