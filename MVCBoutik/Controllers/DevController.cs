using AdopteUneDev.DAL;
using MVCBoutik.Models;
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
            return View();
        }
        
        public ActionResult Details(int id)
        {
            Session["CurrentController"] = this;
            langCategDev HM = new langCategDev()
            {

                LstCateg = Categories.getInfosCategs(),
                LstLang = ITLang.getInfosItLangs(),
                LstDev = Developer.ChargerTousLesDev(),
                CurrentDev = Developer.ChargerUnDev(id),
            };
            return View(HM);
        }
        [HttpPost]
        public ActionResult PostReview(int id,string txtName, string txtMail, string txtText)
        {
            Review.AddReview(id, txtName, txtMail, txtText);
            return new RedirectResult("/Dev/Details/" + id);
        }
        
	}
}