using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PodekexAPI.Model
{
    public class ValidationFilter : IActionFilter
    {
        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
