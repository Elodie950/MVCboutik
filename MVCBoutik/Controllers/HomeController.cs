using AdopteUneDev.DAL;
using MVCBoutik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBoutik.Controllers
{
    public class HomeController : Controller
    {
     //
            // GET: /Home/
            public ActionResult Index()
            {
                langCategDev maBoite = new langCategDev();
                maBoite.LstCateg = Categories.getInfosCategs();
                maBoite.LstLang = ITLang.getInfosItLangs();
                return View(maBoite);
            }
        }
}