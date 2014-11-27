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
        //private int _idCategory;
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
        //public Categories IdCategory
        //{ get; set; }

        #endregion
    }
}
