using AdopteUneDev.DAL;
using MVCBoutik.Areas.Boutik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBoutik.Models
{
    public class panierClient
    {
        private Client _clientCourant;
        private Panier _panierCourant;

        public Client ClientCourant
        {
            get { return _clientCourant; }
            set { _clientCourant = value; }
        }
        public Panier PanierCourant
        {
            get { return _panierCourant; }
            set { _panierCourant = value; }
        }
    }
}