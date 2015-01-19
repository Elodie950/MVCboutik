using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdopteUneDev.DAL
{
    public class Review
    {
        private int _idReview;
        private string _comment;
        private string _name;
        private DateTime _reviewDate;
        private string _email;
        private int _idDev;

        public int IdReview
        {
            get { return _idReview; }
            set { _idReview = value; }
        }

        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public DateTime ReviewDate
        {
            get { return _reviewDate; }
            set { _reviewDate = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public int IdDev
        {
            get { return _idDev; }
            set { _idDev = value; }
        }

        public static List<Review> getReviewsFromDev( int idDev) 
        {
            List<Review> retour = new List<Review>();
            List<Dictionary<string, object>> DesReviews =
            GestionConnexion.Instance.getData("select * from Review where idDev="+ idDev);
           
            foreach (Dictionary<string, object> item in DesReviews)
                 {
                     Review rev = new Review()
                     {
                         IdReview = (int)item["idReview"],
                         IdDev = (int)item["idDev"],
                         Comment = item["Comment"].ToString(),
                         Name = item["Name"].ToString(),
                         ReviewDate= DateTime.Parse(item["ReviewDate"].ToString()),
                         Email = item["Email"].ToString(),
                         
                     };
                     retour.Add(rev);
                     
                 }
            return retour;
             
        }
        public static void AddReview(int id, string txtName, string txtMail, string txtText)
        {
            string query = @"INSERT INTO [AdopteUneDev].[dbo].[Review]
                           ([Name]
                           ,[Comment]
                           ,[Email]
                           ,[idDev])
                            VALUES
                           (@ReviewName,@ReviewText,@ReviewMail,@idDev)";
            Dictionary<string, object> dicovalues = new Dictionary<string, object>();

            dicovalues.Add("ReviewName", txtName);
            dicovalues.Add("ReviewText", txtText);
            dicovalues.Add("ReviewMail", txtMail);
            dicovalues.Add("idDev", id);

            GestionConnexion.Instance.saveData(query, GenerateKey.APP, dicovalues);
        }
    }
}
