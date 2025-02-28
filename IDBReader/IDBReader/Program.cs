using System.Data;

public interface IDbcontext
{
    IDataReader Reader(string sql);
    Object ReadValue(string sql);
    int Create (string sql);
    int Update (string sql);
    int Delete (string sql);
    void OpenConnection();
    void CloseConnection();
    void BeginTransaction();
    public void CommitTransaction();
    public void RollBack();
}