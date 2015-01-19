using MVCBoutik.Areas.Boutik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBoutik.Models
{
    public static class SessionTools
    {
        public static List<Ligne> Panier
        {
            get 
            {
                if (HttpContext.Current.Session["Panier"] == null)
                {
                    HttpContext.Current.Session["Panier"] = new List<Ligne>();
                }
                return (List<Ligne>)HttpContext.Current.Session["Panier"];
            }
            set 
            {
                HttpContext.Current.Session["Panier"] = value;
            }
        }

    }
}