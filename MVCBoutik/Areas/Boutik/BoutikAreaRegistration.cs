using System.Web.Mvc;

namespace MVCBoutik.Areas.Boutik
{
    public class BoutikAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Boutik";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
         
            
            context.MapRoute(
                "Boutik_default",
                "Boutik/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );   
            
            context.MapRoute(
               "Boutik_panier",
               "Boutik/{controller}/{action}/{id}/{qte}/{op}",
               new { action = "Index", id = UrlParameter.Optional }
               );
        }
    }
}