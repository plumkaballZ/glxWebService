namespace Bifrost.ConnMaster
{
    public abstract class init_ConnMaster
    {
        public init_ConnMaster(string server, string db, string user, string pw, uint timeout = 60, uint port = 3306, bool allowZeroDateTime = true)
        {
            //mysql
        }
        public init_ConnMaster(string dataSoruce, string db, string user, string pw, string initialCatalog, int timeout = 1440)
        {
            //sql
        }
    }
}
