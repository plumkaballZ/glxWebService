using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlbXWebService.ConnMaster.help
{
    public class ConnParamz
    {
        private string _spName;
        public string SpName { get { return _spName; } }

        private Dictionary<string, object> _paramDic;
        public Dictionary<string, object> ParamDic { get { return _paramDic; } }

        public ConnParamz(string spName, Dictionary<string, object> paramDic)
        {
            _spName = spName;
            _paramDic = paramDic;
        }
    }
}
