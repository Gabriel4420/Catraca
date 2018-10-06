using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerceWeb.Controllers.Class
{
	public class Authorized:ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if (filterContext.HttpContext.Session["Cliente"] == null)
			{
				filterContext.Result = new RedirectResult("/Cliente/Index");
			}
			base.OnActionExecuting(filterContext);
		}
	}
}