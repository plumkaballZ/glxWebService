using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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

        private IHostingEnvironment _env;
        public xTxtController(IHostingEnvironment env)
        {
            _env = env;
        }

        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        public string Get(string fileName)
        {
            return _env.ContentRootPath + "\\txt\\" + fileName;
            //var txt = System.IO.File.ReadAllLines(_env.ContentRootPath + "\\txt\\" + fileName);
        }

        [HttpPost]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Post([FromBody]GlxUserRequest req)
        {
            var txtFile = JsonConvert.DeserializeObject<TxtFile>(req.jsonStr);

            bool isNewLine = true;

            List<string> arrLines = System.IO.File.ReadAllLines(_env.ContentRootPath + "\\txt\\" + txtFile.fileName).ToList();

            for (int i = 0; i < arrLines.Count(); i++)
            {
                if (txtFile.getBetween(arrLines[i], "[", ":") == txtFile.key)
                {
                    isNewLine = false;
                    arrLines[i] = txtFile.rawStr;
                }
            }

            if (isNewLine) arrLines.Add(txtFile.rawStr);

            System.IO.File.WriteAllLines(_env.ContentRootPath + "\\txt\\" + txtFile.fileName, arrLines);

            return Json("asdf");
        }

        static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = System.IO.File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            System.IO.File.WriteAllLines(fileName, arrLine);
        }


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
