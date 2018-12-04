using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlbXWebService.ConnMaster
{
    public interface IConnectionMaster<T>
    {
        T GetOpenConn();
        string ConnStr { get; set; }
    }
}
