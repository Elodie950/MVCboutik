using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdopteUneDev.DAL
{
    public class DevLang
    {
        #region Fields
        private int _idDev;
        private int _idLang;
        private DateTime? _since;
        #endregion

        #region Properties
        public Developer IdDev
        { get; set; }

        public DevLang Idlang
        { get; set; }

        public DateTime? Since
        {
            get { return _since; }
            set { _since = value; }
        }
        #endregion
        #region Constructor
        #endregion


    }
}
