using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost.ConnMaster_2
{
    public abstract class _baseConnMaster<T>
    {
        public abstract _baseConn _conn { get; set; }
        public abstract void ExecuteSP(ConnMaster2Paramz paramz);
        public abstract string ConnString { get; set; }
    }
}
