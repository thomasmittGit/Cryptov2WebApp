using Cryptov2WebApp.WorkClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Cryptov2WebApp.Filters
{
    public class UserAuth : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (SessionVariables.usuarioLogado == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}