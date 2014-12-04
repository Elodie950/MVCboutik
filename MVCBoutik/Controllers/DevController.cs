using AdopteUneDev.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBoutik.Controllers
{
    public class DevController : Controller
    {
        //
        // GET: /Dev/
        public ActionResult Index()
        {

        }

        public ActionResult Details(int IdDev)
        {
            Developer d = Developer.ChargerUnDev(IdDev);
            return View(d);
        }
	}
}