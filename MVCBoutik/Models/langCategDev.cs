using AdopteUneDev.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBoutik.Models
{
    public class langCategDev
    {
        List<Categories> _lstCateg;
        List<ITLang> _lstLang;
        List<Developer> _lstDev;

        public List<Categories> LstCateg
        {
            get { return _lstCateg; }
            set { _lstCateg = value; }
        }
        public List<ITLang> LstLang
        {
            get { return _lstLang; }
            set { _lstLang = value; }
        }
        public List<Developer> LstDev
        {
            get { return _lstDev; }
            set { _lstDev = value; }
        }

    }
}