using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NzWalkApi.CustomActionFilter
{
	public class ValidateModelAttributes : ActionFilterAttribute
	{

		public void OnActionExecuting(ActionExecutedContext context)
		{
			if (context.ModelState.IsValid == false)
			{
				context.Result = new BadRequestResult();
			}
		
		}
	}
}

