using GymGenius.DataAccess.Models;
using GymGenius.DataAccess;
using GymGenius.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymGenius.Domain.Repositories
{
    public class MachineRepository(IDbContext IDbContext) : IMachinesRepository
    {
        private readonly IDbContext _IDbContext = IDbContext;

        public IEnumerable<MachineModel> Get()//get all 
        {
            const string sql = "SELECT * FROM [Machine]";

            using var data = _IDbContext.ReadSqlData(sql);

            return [];
        }

        public MachineModel Get(string id)
        {
            const string sql = "SELECT * FROM [Machine] WHERE [Machine_ID] = @MachineId";

            using var data = _IDbContext.ReadSqlData(sql, (Name: "@MachineId", Value: id));

            return ModelFactory.NewModel<MachineModel>();
        }

        public bool NewEntity(MachineModel entity)
        {
            string sql = $@"INSERT INTO [Machine] WHERE [Machine_ID] = @MachineId";

            var data = _IDbContext.AddSqlData(sql, (Name: "@MachineId", Value: entity));

            return data;
        }

        public bool RemoveEntity(MachineModel entity)
        {
            //const string sql = $@"DELETE FROM [Machine] WHERE [Machine_ID] = @MachineId";
            var sql = $@"DELETE FROM [Machine] WHERE [Machine_ID] = {entity.Id}";

            var data = _IDbContext.RemoveSqlData(sql);

            return data;
        }

        public bool RemoveEntity(string id)
        {
            const string sql = "SELECT * FROM [Machine] WHERE [Machine_ID] = @MachineId";

            using var data = _IDbContext.ReadSqlData(sql, (Name: "@MachineId", Value: id));

            return data != null;
        }

        public bool UpdateEntity(MachineModel entity)
        {
            const string sql = $@"UPDATE [Machine] set [Machine_Name] = @MachineName where [Machine_ID] = @MachineId";

            var data = _IDbContext.UpdateSqlData(sql, (Name: "@MachineId", Value: entity));

            return data;
        }
    }
}