namespace Bifrost.ConnMaster
{
    public interface IConnMaster<T>
    {
        T GetOpenConn();
        string ConnStr { get; set; }
    }
}
