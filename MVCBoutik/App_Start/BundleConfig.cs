using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MVCBoutik.App_Start
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles) 
        {
            //bundle pour le css
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/css/bootstrap.min.css", "~/Content/css/font-awesome.min.css", "~/Content/css/prettyPhoto.css",
                "~/Content/css/price-range.css", "~/Content/css/animate.css", "~/Content/css/main.css", "~/Content/css/responsive.css"));

            bundles.Add(new ScriptBundle("~/Scripts/Jquery").Include("~/Script/jquery.js" , "~/Script/jquery.scrollUp.min.js","~/Script/jquery.prettyPhoto.js"));

            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include("~/Script/bootstrap.min.js" ));

            bundles.Add(new ScriptBundle("~/Scripts/Custom").Include("~/Script/price-range.js", "~/Script/main.js"));
            
        }
    }
}