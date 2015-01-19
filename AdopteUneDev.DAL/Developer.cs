using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdopteUneDev.DAL
{
    public class Developer
    {
        #region Fields
        private int _idDev;
        private string _devName;
        private string _devFirstName;
        private DateTime _devBirthDate;
        private string _devPicture;
        private double _devHourCost;
        private double _devDayCost;
        private double _devMonthCost;
        private string _devMail;
        private string _NomCategPrincipal;
        private int _devCategPrincipal;
        private List<ITLang> _itLangs;
        private List<Review> _reviews;
        
        #endregion

        #region Proprieties
        public int IdDev 
        {
            get { return _idDev; }
            set { _idDev = value; }
        }
        public string DevName
        {
            get { return _devName; }
            set { _devName = value; }
        }
        public string DevFirstName
        {
            get { return _devFirstName; }
            set { _devFirstName = value; }
        }
        public DateTime DevBirthDate
        {
            get { return _devBirthDate; }
            set { _devBirthDate = value; }
        }
        public string DevPicture
        {
            get { return _devPicture; }
            set { _devPicture = value; }
        }
        public double DevHourCost
        {
            get { return _devHourCost; }
            set { _devHourCost = value; }
        }
        public double DevDayCost
        {
            get { return _devDayCost; }
            set { _devDayCost = value; }
        }
        public double DevMonthCost
        {
            get { return _devMonthCost; }
            set { _devMonthCost = value; }
        }
        public string DevMail
        {
            get { return _devMail; }
            set { _devMail = value; }
        }
        public string NomCategPrincipal
        {
            get {
                if (_NomCategPrincipal == null)
                {
                    _NomCategPrincipal = ChargerNomCateg();
                }
                return _NomCategPrincipal;
            }
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
        public int DevCategPrincipal
        {
            get { return _devCategPrincipal; }
            set { _devCategPrincipal = value; }
        }

        public List<Review> Reviews
        {
            get {
                if (_reviews == null)
                {
                    _reviews = ChargerLesReviews();
                }
                return _reviews; }
            set { _reviews = value; }
        }
        #endregion


        #region Static
        private string ChargerNomCateg()
        {
            List<Dictionary<string, object>> maCateg = GestionConnexion.Instance.getData("select CategLabel from Categories where idCategory=" + this.DevCategPrincipal);
            string categName = "";
            if (maCateg[0]["CategLabel"] != null) categName = maCateg[0]["CategLabel"].ToString();
            return categName;
           
        }

         private List<ITLang> ChargerLesITLangs() 
        {
            string query = @"select i.idIT,i.ITLabel from ITLang  i
                            inner join DevLang d
                            on d.idIT = i.idIT
                            where d.Developer =" + this.IdDev;
            List<ITLang> retour = new List<ITLang>();
            List<Dictionary<string, object>> MesLangs = GestionConnexion.Instance.getData(query);
            
            foreach(Dictionary<string, object> item in MesLangs)
            {
                ITLang l = new ITLang();
                l.IdIT = (int)item["idIT"];
                l.ITLabel = item["ITLabel"].ToString();
                retour.Add(l);
            }
            return retour;
        }

         private List<Review> ChargerLesReviews()
         {
             return Review.getReviewsFromDev(this.IdDev);
         }
        /// <summary>
         /// Peremet de récupérer la totalité des développeurs
         /// </summary>
         /// <returns>Une liste de Developer</returns>
         public static List<Developer> ChargerTousLesDev()
         {
             List<Dictionary<string, object>> lstDevs =
                 GestionConnexion.Instance.getData("select * from Developer");
             List<Developer> retour = new List<Developer>();
             foreach (Dictionary<string, object> item in lstDevs)
             {
                 Developer dev = Associe(item);
                 retour.Add(dev);
             }
             return retour;
         }
         /// <summary>
         /// Permet de récupérer 1 developpeur à partir de son ID
         /// </summary>
         /// <param name="idD">Id du developpeur a charger</param>
         /// <returns>Le developpeur</returns>
         public static Developer ChargerUnDev(int idD)
         {
             List<Dictionary<string, object>> UnDev =
             GestionConnexion.Instance.getData("select * from Developer where idDev=" + idD);
             Developer dev = Associe(UnDev[0]);
             return dev;
         }
         /// <summary>
         /// Permet d'associer les champs du dictionnaire aux propriétés correspondantes
         /// </summary>
         /// <param name="item">Un dictionnaire (nom col, valeur)</param>
         /// <returns></returns>
         private static Developer Associe(Dictionary<string, object> item)
         {
             Developer dev = new Developer()
                {
                    IdDev = (int)item["idDev"],
                    DevName = item["DevName"].ToString(),
                    DevFirstName = item["DevFirstName"].ToString(),
                    DevBirthDate = DateTime.Parse(item["DevBirthDate"].ToString()),
                    DevDayCost = (double)item["DevDayCost"],
                    DevMail = item["DevMail"].ToString(),
                    DevHourCost = (double)item["DevHourCost"],
                    DevMonthCost = (double)item["DevMonthCost"],
                    DevCategPrincipal = (int)item["DevCategPrincipal"],
                    DevPicture = item["DevPicture"] == null ? "" : item["DevPicture"].ToString(),
                };
             return dev;
         }
        
         #endregion
        /*public static Developer getInfo(int identifiant)
        {
            List<Dictionary<string, object>> infoDev = GestionConnexion.Instance.getData("Select * from Developer where idDev=" + identifiant);
            Developer d = new Developer();
           
                 d.IdDev = int.Parse(infoDev[0]["idDev"].ToString());
                 d.DevName = infoDev[0]["DevName"].ToString();
                 d.DevFirstName = infoDev[0]["DevFirstName"].ToString();
                 d.DevBirthDate = DateTime.Parse(infoDev[0]["DevBirthDate"].ToString());
                 d._devPicture = infoDev[0]["DevPicture"].ToString();
                 d.DevHourCost = float.Parse(infoDev[0]["DevHourCost"].ToString());
                 d.DevDayCost = float.Parse(infoDev[0]["DevDayCost"].ToString());
                 d.DevMonthCost = float.Parse(infoDev[0]["DevMonthCost"].ToString());
                 d.DevMail = infoDev[0]["DevMail"].ToString();
            
            return d;
        }
       
        #endregion

        #region Functions
        /// <summary>
        /// Peremet de sauvegarder une personne dans la DB
        /// </summary>
        /// <returns>true si l'insertion est OK</returns> 
        public virtual bool saveMe()
        {
            //Requête
            Developer d = Developer.getInfo(this.IdDev);
            string query = "";
            if (d == null)
            {

                query = @"INSERT INTO [AdopteUneDev].[dbo].[Developer]
     VALUES
           (@DevName, @DevFirstName, @DevBirthDate, @DevPicture, @DevHourCost, @DevDayCost, @DevMonthCost, @DevMail)";

            }
            else
            {
                query = @"UPDATE [AdopteUneDev].[dbo].[Developer]
                                        SET 
                                            [DevName] = @DevName,
                                            [DevFirstName] = @DevFirstName,
                                            [DevBirthDate] = @DevBirthDate,
                                            [DevPicture] = @DevPicture,
                                            [DevHourCost] = @DevHourCost,
                                            [DevDayCost] = @DevDayCost,
                                            [DevMonthCost] = @DevMonthCost,
                                            [DevMail] = @DevMail,
                                            WHERE [idDev] = @idDev";
            }

            //les données a insérer
            Dictionary<string, object> valeurs = new Dictionary<string, object>();
            valeurs.Add("idDev", this.IdDev);
            valeurs.Add("DevName", this.DevName);
            valeurs.Add("DevFirstName", this.DevFirstName);
            valeurs.Add("DevBirthDate", this.DevBirthDate);
           //si picture à une valeur, on l'insère sinon on mets à null dans la db
            valeurs.Add("DevPicture", this.DevPicture == default(string) ? DBNull.Value : (object)this.DevPicture);
            valeurs.Add("DevHourCost", this.DevHourCost);
            valeurs.Add("DevDayCost", this.DevDayCost);
            valeurs.Add("DevMonthCost", this.DevMonthCost);
            valeurs.Add("DevMail", this.DevMail);
         



            if (GestionConnexion.Instance.saveData(query, GenerateKey.APP, valeurs))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static List<Developer> getInfos()
        {
            List<Dictionary<string, object>> infoDeveloper = GestionConnexion.Instance.getData("Select * from Developer");
            List<Developer> retour = new List<Developer>();
            foreach (Dictionary<string, object> item in infoDeveloper)
            {
                Developer d = new Developer();
                d.IdDev = int.Parse(item["idDev"].ToString());
                d.DevName = item["DevName"].ToString();
                d.DevFirstName = item["DevFirstName"].ToString();
                d.DevBirthDate = DateTime.Parse(item["DevBirthDate"].ToString());
                d.DevPicture= item["DevPicture"].ToString();
                d.DevHourCost = float.Parse(item["DevHourCost"].ToString());
                d.DevDayCost = float.Parse(item["DevDayCost"].ToString());
                d.DevMonthCost = float.Parse(item["DevMonthCost"].ToString());
                d.DevMail = item["DevMail"].ToString();
                retour.Add(d);
            }
            return retour;
        }
        #endregion*/

         public object ChargerUnDev()
         {
             throw new NotImplementedException();
         }
    }
}
