using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GlbXWebService.Controllers
{
    [Route("api/[controller]")]
    public class xTxtController : Controller
    {

        private string srvPath;

        private IHostingEnvironment _env;
        public xTxtController(IHostingEnvironment env)
        {
            _env = env;
            srvPath = "C:\\super_dev_Z\\glxWebService\\GlbXWebService\\i18n\\";
            //srvPath = "/home/plumka/website/glxWebService/GlbXWebService/i18n/";
        }

        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Get(string fileName)
        {

            var json = System.IO.File.ReadAllText(srvPath + fileName);

            return new JsonResult(JsonConvert.DeserializeObject(json));
        }

        [HttpPost]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Post([FromBody]GlxUserRequest req)
        {
            var i18 = JsonConvert.DeserializeObject<i_18_Object>(req.jsonStr);

            var jsonFile = System.IO.File.ReadAllText(srvPath + i18.fileName);

            JObject jsonObj = JsonConvert.DeserializeObject<JObject>(jsonFile);

            JObject page = jsonObj[i18.page] as JObject;

            if (page == null)
                jsonObj.Add(i18.page, JObject.Parse(@"{""" + i18.key + @""":""" + i18.line + @"""}"));

            if (page != null)
            {
                var key = page[i18.key];

                if (key == null)
                    page.Add(i18.key,  i18.line);

                if (key != null)
                    jsonObj[i18.page][i18.key] = i18.line;
            }

            System.IO.File.WriteAllText(srvPath + i18.fileName, jsonObj.ToString());

            return Json("asdf");
        }

        static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = System.IO.File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            System.IO.File.WriteAllLines(fileName, arrLine);
        }
    }

    public class i_18_Object
    {
        public string fileName { get; set; }
        public string page { get; set; }
        public string key { get; set; }
        public string line { get; set; }

    }

    public class TxtFile
    {
        public string key
        {
            get { return getBetween(rawStr, "[", ":"); }
        }
        public string line
        {
            get { return getBetween(rawStr, key + ":", "]"); }
        }

        public string fileName { get; set; }
        public string rawStr { get; set; }

        public string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
    }
}
