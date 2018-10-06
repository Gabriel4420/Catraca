using System.Web.Mvc;

namespace eCommerceWeb.Controllers.HomeController
{
	public class HomeController : Controller
    {
        // GET: Home
        public ActionResult LayoutInicial()
        {
			Session["Cliente"] = null;
			return View();
        }

      
        
    }
}
