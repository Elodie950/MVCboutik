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
        private List<Developer> _developers;
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
            get { return _categories = _categories ?? ChargerLesCategories(); }
        }
        public List<Developer> Developer
        {
            get { return _developers = _developers ?? ChargerLesDevelopers(); }
        }
        

        #endregion


        #region Static
        private List<Developer> ChargerLesDevelopers()
        {
            string query = @"select d.idDev, d.DevName, d.DevFirstName, d.DevBirthDate, d.DevDayCost, d.DevMail, d.DevHourCost, d.DevMonthCost,d.DevPicture from Developer d
                            inner join DevLang de 
                            on d.idDev = de.idDev
                            where de.idIT =" + this.IdIT;
            List<Dictionary<string, object>> MesDevelopers = GestionConnexion.Instance.getData(query);
            List<Developer> retour = new List<Developer>();
            foreach (Dictionary<string, object> item in MesDevelopers)
            {
                Developer d = new Developer();
                d.IdDev = (int)item["idDev"];
                d.DevName = item["DevName"].ToString();
                d.DevFirstName = item["DevFirstName"].ToString();
                d.DevBirthDate = DateTime.Parse(item["DevBirthDate"].ToString());
                d.DevDayCost = (double)item["DevDayCost"];
                d.DevMail = item["DevMail"].ToString();
                d.DevHourCost = (double)item["DevHourCost"];
                d.DevMonthCost = (double)item["DevMonthCost"];
                d.DevPicture = item["DevPicture"] == null ? "" : item["DevPicture"].ToString();
                retour.Add(d);
            }
            return retour;
        }
        private List<Categories> ChargerLesCategories()
        {
            string query = @"select * from Categories c
                            inner join LangCateg l 
                            on c.idCategory = l.idCategory
                            where l.idIT =" + this.IdIT;
            List<Dictionary<string, object>> MesCategories = GestionConnexion.Instance.getData(query);
            List<Categories> retour = new List<Categories>();
            foreach (Dictionary<string, object> item in MesCategories)
            {
                Categories c = new Categories();
                c.IdCategory = (int)item["idCategory"];
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
            foreach (Dictionary<string, object> item in infoLesLangues)
            {

                retour.Add(Associe(item));
            }
            return retour;
        }

        private static ITLang Associe(Dictionary<string, object> infoUnelang)
        {
            ITLang itl = new ITLang();
            itl.IdIT = (int)infoUnelang["idIT"];
            itl.ITLabel = infoUnelang["ITLabel"].ToString();
            return itl;
        }
        #endregion
    }
}
