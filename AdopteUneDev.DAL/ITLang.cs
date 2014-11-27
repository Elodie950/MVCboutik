using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdopteUneDev.DAL
{
    public class ITLang
    {
        #region Fields
        private int _idIT;
        private string _iTLabel;
        private List<Categories> _categories;
        #endregion

        #region Properties
        public int IdIT
        {
            get { return _idIT; }
            set { _idIT = value; }
        }
        public string ITLabel
        {
            get { return _iTLabel; }
            set { _iTLabel = value; }
        }
        public List<Categories> Categories
        {
            get { return _categories; }
        }
        //public Categories IdCategory
        //{ get; set; }

        #endregion


        #region Static
        private List<Categories> ChargerLesCategories()
        {
            string query = @"Select * from LangCateg c inner join ITLang i  on c.idIT = i.idIT where i.idIT=" + this.IdIT;
            List<Dictionary<string, object>> MesCategories = GestionConnexion.Instance.getData(query);
            List<Categories> retour = new List<Categories>();
            foreach (Dictionary<string, object> item in MesCategories)
            {
                Categories c = new Categories();
                c.IdCategory = int.Parse(item["idCategory"].ToString());
                c.CategLabel = item["categLabel"].ToString();
                retour.Add(c);
            }
            return retour;
        }

        public static ITLang getInfoItLang(int identifiant)
        {
            List<Dictionary<string, object>> infoUnelang = GestionConnexion.Instance.getData("Select * from ITLang where idIT= " + identifiant);
            ITLang l = Associe(infoUnelang[0]);
            return l;

        }

        public static List<ITLang> getInfosItLangs()
        {
            List<Dictionary<string, object>> infoLesLangues = GestionConnexion.Instance.getData("Select * from ITLang");
            List<ITLang> retour = new List<ITLang>();
            foreach (var item in infoLesLangues)
            {

                retour.Add(Associe(item));
            }
            return retour;
        }

        private static ITLang Associe(Dictionary<string, object> infoUnelang)
        {
            ITLang itl = new ITLang();
            itl.IdIT = int.Parse(infoUnelang["idIT"].ToString());
            itl.ITLabel = infoUnelang["iTLabel"].ToString();
            return itl;
        }
        #endregion
    }
}
