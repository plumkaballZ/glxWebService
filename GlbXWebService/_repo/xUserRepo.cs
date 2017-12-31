using Bifrost.ConnMaster;
using GlbXWebService.Controllers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlbXWebService._repo
{
    public class xUserRepo : _baseRepo
    {
        private IConnMaster<MySqlConnection> _conn;
        public xUserRepo()
        {
        }
        public string CreateLogin(GlxUser xUserLogin)
        {
            Dictionary<string, object> paramDic = new Dictionary<string, object>();

            paramDic.Add("@_email", xUserLogin.email);
            paramDic.Add("@pw", xUserLogin.password);
            paramDic.Add("@mobile", xUserLogin.mobile);


            return Conn.GetSingle<string>("xUserLogin_Create", paramDic);
        }
        public bool Create(string loginUid)
        {
            Dictionary<string, object> paramDic = new Dictionary<string, object>();

            paramDic.Add("@loginUid", loginUid);
            Conn.ExecuteSP("xUser_Create", paramDic);

            return true;
        }
        public xUser GetSignle(string refUid)
        {
            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            paramDic.Add("@loginUid", refUid);

            return Conn.GetSingle<xUser>("xUser_GetSingle", paramDic);
        }
        public bool CheckLogin(string email)
        {
            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            paramDic.Add("@email", email);
            return Conn.GetSingle<int>("xUserLogin_Check", paramDic) == 1 ? true : false;
        }
        public string Login(string email, string pw)
        {
            Dictionary<string, object> paramDic = new Dictionary<string, object>();

            paramDic.Add("@_email", email);
            paramDic.Add("@_pw", pw);

            return Conn.GetSingle<string>("xUserLogin_Login", paramDic);
        }
    }
}
