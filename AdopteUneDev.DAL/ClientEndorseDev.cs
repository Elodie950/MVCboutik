using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdopteUneDev.DAL
{
    public class ClientEndorseDev
    {
        #region Fields
        private int _idClient;
        private int _idDev;
        private DateTime _beginDate;
        private DateTime _endDate;
        private Guid _endrorseNumber;
        #endregion 

        #region Properties
        public Client IdClient
        { get; set; }

        public Developer IdDev
        { get; set; }

        public DateTime BeginDate
        {
            get { return _beginDate; }
            set { _beginDate = value; }
        }
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value;}
        }
        public Guid EndorseNumber
        {
            get { return _endrorseNumber; }
            set { _endrorseNumber = value; }
        }
        #endregion 
    }
}
