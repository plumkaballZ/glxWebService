using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost.ConnMaster_2
{
    public class ConnMaster2Paramz
    {
        private string _spName;
        public string SpName { get { return _spName; } }

        private Dictionary<string, object> _paramDic;
        public Dictionary<string, object> ParamDic { get { return _paramDic; } }

        public ConnMaster2Paramz(string spName, Dictionary<string, object> paramDic)
        {
            _spName = spName;
            _paramDic = paramDic;
        }
    }
}
