using AdopteUneDev.DAL;
using MVCBoutik.Areas.Boutik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBoutik.Models
{
    public static class SessionTools
    {
        public static Panier Panier
        {
            get 
            {
                if (HttpContext.Current.Session["Panier"] == null)
                {
                    HttpContext.Current.Session["Panier"] = new Panier();
                }
                return (Panier)HttpContext.Current.Session["Panier"];
            }
            set 
            {
                HttpContext.Current.Session["Panier"] = value;
            }
        }

        public static string Login
        {
            get
            {
                try
                {
                    return HttpContext.Current.Session["Login"].ToString();
                }
                catch
                {
                    return null;
                }
            }
            set { HttpContext.Current.Session["Login"] = value; }
        }

        public static Client client
        {
            get
            {
                if (HttpContext.Current.Session["Client"] == null)
                {
                    HttpContext.Current.Session["Client"] = new Client();
                }
                return (Client)HttpContext.Current.Session["Client"];
            }
            set
            {
                HttpContext.Current.Session["Client"] = value;
            }
        }
    }
}