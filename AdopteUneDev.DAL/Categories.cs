using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdopteUneDev.DAL
{
    public class Categories
    {
        #region Fields
        private int _idCategory;
        private string _categLabel;
        private List<ITLang> _itLangs; //navigation property -> permet de naviguer dans les tables de la db
        #endregion 

        #region Proprieties
        public int IdCategory
        {
            get { return _idCategory; }
            set { _idCategory = value; }
        }
        public string CategLabel
        {
            get { return _categLabel; }
            set { _categLabel = value; }
        }
        public List<ITLang> ItLangs
        {
            get
            {
                if (_itLangs == null)
                {
                    _itLangs = ChargerLesITLangs();
                } 
                return _itLangs;
            } //return _itLangs = _itLangs?? ChargerLesITLangs();
        }

        #endregion

       
        #region Static
        private List<ITLang> ChargerLesITLangs() 
        {
            string query=@"Select * from ITLang i inner join LangCateg c on c.idIT = i.idIT where c.idCategory=" + this.IdCategory;
            List<Dictionary<string, object>> MesLangs = GestionConnexion.Instance.getData(query);
            List<ITLang> retour = new List<ITLang>();
            foreach(Dictionary<string, object> item in MesLangs)
            {
                ITLang l = new ITLang();
                l.IdIT = (int)item["idIT"];
                l.ITLabel = item["ITLabel"].ToString();
                retour.Add(l);
            }
            return retour;
        }

        public static Categories getInfoCat(int identifiant)
        {
            List<Dictionary<string, object>> infoUneCateg = GestionConnexion.Instance.getData("Select * from Categories where idCategory= " + identifiant);
            Categories cat = Associe(infoUneCateg[0]);
            return cat;

        }

        public static List<Categories> getInfosCategs()
        {
            List<Dictionary<string, object>> infoLesCateg = GestionConnexion.Instance.getData("Select * from Categories");
            List<Categories> retour = new List<Categories>();
            foreach (var item in infoLesCateg)
            {

                retour.Add(Associe(item));
            }
            return retour;
        }

        private static Categories Associe(Dictionary<string, object> infoUneCateg)
        {
            Categories cat = new Categories();
            cat.IdCategory = int.Parse(infoUneCateg["idCategory"].ToString());
            cat.CategLabel = infoUneCateg["categLabel"].ToString();
            return cat;
        }
        #endregion

    }
}
