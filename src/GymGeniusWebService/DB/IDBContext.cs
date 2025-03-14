using System.Data;

namespace GymGeniusWebService.DB
{
    public interface IDBContext
    {
        void OpenConnection();
        void CloseConnection();
        IDataReader Read(string sql);
        object ReadValue(string sql);
        bool Update(string sql);
        bool Delete(string sql);
        bool Insert(string sql);

        void Commit();
        void Rollback();

    }
}
