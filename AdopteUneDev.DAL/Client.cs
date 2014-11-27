using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdopteUneDev.DAL
{
    public class Client
    {
        #region Fields
        private int _idClient;
        private string _cliName;
        private string _cliFirstName;
        private string _cliMail;
        private string _cliCompany;
        #endregion 

        #region Proprieties
        public int IdClient 
        {
            get { return _idClient; }
            set { _idClient = value;  }
        }
        public string CliName
        {
            get { return _cliName; }
            set { _cliName = value; }
        }
        public string CliFirstName
        {
            get { return _cliFirstName; }
            set { _cliFirstName = value; }
        }
        public string CliMail
        {
            get { return _cliMail; }
            set { _cliMail = value; }
        }
        public string CliCompany
        {
            get { return _cliCompany; }
            set { _cliCompany = value; }
        }
        #endregion

        #region Constructor
        public Client()
        { 
        }
        public Client(int idClient, string cliName, string cliFirstName, string cliMail, string cliCompany) 
        {
            this.IdClient = idClient;
            this.CliName = cliName;
            this.CliFirstName = cliFirstName;
            this.CliMail = cliMail;
            this.CliCompany = cliCompany;

        }
        #endregion

        #region Static
        public static Client getInfo(int identifiant)
        {
            List<Dictionary<string, object>> infoClient = GestionConnexion.Instance.getData("Select * from Client where idClient= " + identifiant);
            Client c = new Client();

                c.IdClient = int.Parse(infoClient[0]["idClient"].ToString());
                c.CliName = infoClient[0]["CliName"].ToString();
                c.CliFirstName = infoClient[0]["CliFirstName"].ToString();
                c.CliMail = infoClient[0]["CliMail"].ToString();
                c.CliCompany = infoClient[0]["CliCompany"].ToString();

            return c;
          
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
            Client c = Client.getInfo(this.IdClient);
            string query = "";
            if (c == null)
            {

                query = @"INSERT INTO [AdopteUneDev].[dbo].[Client]
            VALUES
           (@idClient,@CliName,@CliFirstName, @CliMail, @CliCompany)";

            }
            else
            {
                query = @"UPDATE [AdopteUneDev].[dbo].[Client]
                                        SET [CliName] = @CliName,
                                            [CliFirstName] = @CliFirstName,
                                            [CliMail] = @CliMail,
                                            [CliCompany] = @CliCompany,
                                            WHERE [idClient] = @idClient";
            }

            //les données a insérer
            Dictionary<string, object> valeurs = new Dictionary<string, object>();
            valeurs.Add("CliName", this.CliName);
            valeurs.Add("CliFirstName", this.CliFirstName);
            valeurs.Add("CliMail", this.CliMail);
            valeurs.Add("CliCompany", this.CliCompany);
            if (GestionConnexion.Instance.saveData(query, GenerateKey.APP, valeurs))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<Client> getInfos()
        {
            List<Dictionary<string, object>> infoPersonne = GestionConnexion.Instance.getData("Select * from Client");
            List<Client> retour = new List<Client>();
            foreach (Dictionary<string, object> item in infoPersonne)
            {
                Client c = new Client();
                //7.2.1- Construction de l'objet personne
                c.IdClient = int.Parse(item["idClient"].ToString());
                c.CliName = item["CliName"].ToString();
                c.CliFirstName = item["CliFirstName"].ToString();
                c.CliMail = item["CliMail"].ToString();
                c.CliCompany = item["CliCompany"].ToString();
                retour.Add(c);
            }
            return retour;
        }
        #endregion
    }
}
