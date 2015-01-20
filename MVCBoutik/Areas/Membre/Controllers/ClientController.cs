using AdopteUneDev.DAL;
using MVCBoutik.Areas.Boutik.Models;
using MVCBoutik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBoutik.Areas.Membre.Controllers
{
    public class ClientController : Controller
    {
        //
        // GET: /Membre/Client/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SeLogger()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SeLogger(string txtLogin, string txtPassword)
        {
            if (SessionTools.Login == null)
            {
                Client c = Client.AuthentifieMoi(txtLogin, txtPassword);
                if (c == null)
                {
                    return View();
                }
                else
                {
                    SessionTools.Login = txtLogin;
                    SessionTools.client = c;
                }
            }
            return RedirectToRoute(new { controller = "Home", action = "Index", area = "" });
        }


        public RedirectToRouteResult Logoff()
        {
            SessionTools.Login = null;
            Session.Abandon();
            return RedirectToRoute(new { controller = "Home", action = "Index", area = "" });
        }

        [HttpPost]
        public ActionResult Inscription(string txtnom, string txtprenom, string txtemail)
        {
            logger l = new logger(txtnom, txtprenom, txtemail);
            return View(l);
        }

        [HttpPost]
        public ActionResult InscriptionFin(string txtName, string CliFirstName, string CliMail, string CliCompany, string CliLogin, string CliPassword)
        {
            Client c = new Client();
            c.InsererClient(txtName, CliFirstName, CliMail, CliCompany, CliLogin, CliPassword);
            return RedirectToRoute(new { controller = "Home", action = "Index", area = "" });


        }
	}
}