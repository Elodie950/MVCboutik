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
        private float _devHourCost;
        private float _devDayCost;
        private float _devMonthCost;
        private string _devMail;
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
        public float DevHourCost
        {
            get { return _devHourCost; }
            set { _devHourCost = value; }
        }
        public float DevDayCost
        {
            get { return _devDayCost; }
            set { _devDayCost = value; }
        }
        public float DevMonthCost
        {
            get { return _devMonthCost; }
            set { _devMonthCost = value; }
        }
        public string DevMail
        {
            get { return _devMail; }
            set { _devMail = value; }
        }
        #endregion

        #region Constructor
        public Developer() 
        { 
        }
        public Developer(int idDev, string devName, string devFirstName, DateTime devBirthDate, float devHourCost, float devDayCost, float devMonthCost, string devMail, string devPicture = default(string))
        {
            this.IdDev = idDev;
            this.DevName = devName;
            this.DevFirstName = devFirstName;
            this.DevBirthDate = devBirthDate;
            this.DevPicture = devPicture;
            this.DevHourCost = devHourCost;
            this.DevDayCost = devDayCost;
            this.DevMonthCost = devMonthCost;
            this.DevMail = devMail; 
        }
        #endregion

        #region Static
        public static Developer getInfo(int identifiant)
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
        #endregion
    }
}
