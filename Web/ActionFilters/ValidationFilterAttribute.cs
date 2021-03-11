using Autobiography.Data;
using Autobiography.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Net;

namespace Web.ActionFilters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string tokenUserId = context.HttpContext.User.FindFirst("Id").Value;
            string requestUserId = context.ActionArguments["id"].ToString();

            if (tokenUserId != requestUserId)
            {
                context.ModelState.AddModelError("error:", "You don't have access to foreign properties!");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
