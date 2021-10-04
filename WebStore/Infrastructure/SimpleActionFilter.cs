using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace WebStore.Controllers
{
    internal class SimpleActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //предобработка
            throw new NotImplementedException();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //постобработка
            throw new NotImplementedException();
        }

        
    }
}