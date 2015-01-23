using AdopteUneDev.DAL;
using MVCBoutik.Areas.Boutik.Models;
using MVCBoutik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBoutik.Areas.Boutik.Controllers
{
    public class PanierController : Controller
    {
        //
        // Renvoi la vue AddToBasket (même vide car ne nécessite pas de paramètres) 
        // Action renseignée pour les liens dans le layout et la vue index
        public ActionResult Index()
        {
            return View("AddToBasket", SessionTools.Panier);
        }

        //Envoi les information pour créer une nouvelle ligne
        [HttpPost]
        public ActionResult AddToBasket(int dev, int qte, int choix, DateTime dateDebut)
        {
            //if (SessionTools.Login == null)
            //{
            //    return RedirectToRoute(new { controller = "Home", action = "Index", area = "" });
            //}
            //else
            //{
                if (qte < 1) // pour ne pas avoir un prix négatif
                {
                    return RedirectToRoute(new { controller = "Home", action = "Index", area = "" });
                }
                else
                {
                    Developer d = Developer.ChargerUnDev(dev);
                    if (SessionTools.Panier.Lignes.Where(li => li.ZeDave.IdDev == dev).Count() > 0) //vérifie si le déveloper est déjà dans le panier
                    {
                        return RedirectToRoute(new { controller = "Home", action = "Index", area = "" }); //si oui, on ne peux pas l'ajouter!
                    }
                    Ligne l = new Ligne() { ZeDave = d, Qte = qte, Choix = choix, DateDebut = dateDebut };
                    SessionTools.Panier.Lignes.Add(l);
                }
                return View("AddToBasket", SessionTools.Panier);

            }
        //}

        // permet d'augmenter ou de diminuer la quantité
        //booleen déclarer à true pour le plus et à false pour le - dans la vue partielle _Ligne
        [HttpGet]
        public ActionResult AddToBasket(int id, int qte, bool op)
        {

            if (SessionTools.Panier.Lignes.Where(li => li.ZeDave.IdDev == id).Count() > 0) // vérifie qu'il y a un developer
            {
                if (op) // si le booléen 
                {
                    SessionTools.Panier.Lignes.Where(li => li.ZeDave.IdDev == id).FirstOrDefault().Qte += qte;
                }
                else
                {
                    SessionTools.Panier.Lignes.Where(li => li.ZeDave.IdDev == id).FirstOrDefault().Qte -= qte;
                }
                if (SessionTools.Panier.Lignes.Where(li => li.ZeDave.IdDev == id).FirstOrDefault().Qte < 1) SessionTools.Panier.Lignes.Remove(SessionTools.Panier.Lignes.Where(li => li.ZeDave.IdDev == id).FirstOrDefault());
            }
            return View("AddToBasket", SessionTools.Panier);
        }

        [HttpPost]
        public ActionResult SupLigne(int id)
        {
            Ligne c = null; 
            foreach (Ligne e in SessionTools.Panier.Lignes)
            {
                if (e.ZeDave.IdDev == id)
                {
                    c = e;
                }
            }
            SessionTools.Panier.Lignes.Remove(c);
            //Equivalent du foreach ci-dessus => SessionTools.Panier.Remove(SessionTools.Panier.Lignes.Where(e=>e.ZeDave.IdDev==id).Single());
            return View("AddToBasket", SessionTools.Panier);
        }

        public ActionResult ConfirmerPanier()
        {
            if (SessionTools.Login == null)
            {
                return RedirectToRoute(new { controller = "Client", action = "SeLogger", area = "Membre" });
            }
            else 
            {
                panierClient p = new panierClient()
                {
                    ClientCourant = SessionTools.client,
                    PanierCourant = SessionTools.Panier,
                };
               return View(p);
            }
            
        }
	}
}