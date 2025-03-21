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
    public class PlanRepository(DbContext dbContext) : IPlanRepository
    {
        private readonly DbContext _dbContext = dbContext;

        public IEnumerable<PlanModel> Get()//get all 
        {
            const string sql = "SELECT * FROM [Plan]";

            using var data = _dbContext.ReadSqlData(sql);

            return [];
        }

        public PlanModel Get(string id)
        {
            const string sql = "SELECT * FROM [Plan] WHERE [Plan_ID] = @PlanId";

            using var data = _dbContext.ReadSqlData(sql, (Name: "@PlanId", Value: id));

            return ModelFactory.NewModel<PlanModel>();
        }

        public bool NewEntity(PlanModel entity)
        {
            string sql = $@"INSERT INTO [Plan] WHERE [Plan_ID] = @PlanId";

            var data = _dbContext.AddSqlData(sql, (Name: "@PlanId", Value: entity));

            return data;
        }

        public bool RemoveEntity(PlanModel entity)
        {
            //const string sql = $@"DELETE FROM [Plan] WHERE [Plan_ID] = @PlanId";
            var sql = $@"DELETE FROM [Plan] WHERE [Plan_ID] = {entity.Id}";

            var data = _dbContext.RemoveSqlData(sql);

            return data;
        }

        public bool RemoveEntity(string id)
        {
            const string sql = "SELECT * FROM [Plan] WHERE [Plan_ID] = @PlanId";

            using var data = _dbContext.ReadSqlData(sql, (Name: "@PlanId", Value: id));

            return data != null;
        }

        public bool UpdateEntity(PlanModel entity)
        {
            const string sql = $@"UPDATE [Plan] set [Plan_Name] = @PlanName where [Plan_ID] = @PlanId";

            var data = _dbContext.UpdateSqlData(sql, (Name: "@PlanId", Value: entity));

            return data;
        }
    }
}