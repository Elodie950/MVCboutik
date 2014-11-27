using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdopteUneDev.DAL
{
    public class LangCateg
    {
        #region Fields
        private int _idIT;
        private int _idCategory;
        #endregion

        #region Properties
        public ITLang IdIT
        { get; set; }

        public Categories IdCategory
        {  get; set;  }
        #endregion
    }
}
