using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost.ConnMaster_2
{
    public interface IConn<T>
    {
        string _connStr { get; set; }
        T GetOpenConn();
    }
}
