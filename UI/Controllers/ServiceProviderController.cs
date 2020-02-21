using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class ServiceProviderController : Controller
    {
	    public ActionResult Index(int? categoryId,int? cityId)
	    {
        //todo: refine collection send to view
		    return View();
	    }
	    
	    public ActionResult Profile()
	    {
		    return View();
	    }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
    }
}