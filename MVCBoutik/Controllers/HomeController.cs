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
                Session["CurrentController"] = this;
                langCategDev HM = new langCategDev()
           {

               LstCateg = Categories.getInfosCategs(),
               LstLang = ITLang.getInfosItLangs(),
               LstDev = Developer.ChargerTousLesDev(),
           };
                return View(HM);
            }
        }
}