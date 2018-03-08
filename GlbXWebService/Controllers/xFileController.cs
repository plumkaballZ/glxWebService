using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlbXWebService.Controllers
{

    public class xFileController : Controller
    {
        private string srvPath;
        public xFileController()
        {
            //srvPath = "C:\\super_dev_Z\\glxWebService\\GlbXWebService\\i18n\\";
            srvPath = "/home/plumka/website/glxWebService/GlbXWebService/i18n/";
        }
    }
}
