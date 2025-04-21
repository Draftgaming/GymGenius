using GymGenius.DataAccess.Models;
using GymGenius.DataAccess;
using GymGenius.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymGenius.Domain.Extensions;

namespace GymGenius.Domain.Repositories
{
    public class PlanRepository(IDbContext dbContext) : IPlanRepository
    {
        private readonly IDbContext _dbContext = dbContext;

        public IEnumerable<PlanModel> Get()//get all 
        {
            const string sql = "SELECT * FROM [Plans]";

            return _dbContext.ReadSqlData(sql).GetEntities<PlanModel>();
        }

        public PlanModel Get(string id)
        {
            const string sql = "SELECT * FROM [Plans] WHERE [Plan_ID] = @PlanId";

            using var data = _dbContext.ReadSqlData(sql, (Name: "@PlanId", Value: id));

            return ModelFactory.NewModel<PlanModel>();
        }

        public bool NewEntity(PlanModel entity)
        {
            
            string sql = $"INSERT INTO [Plans] (Plan_Exercise, Plan_Name) VALUES ('{entity.PlanExercise}', '{entity.PlanName}')";

            var data = _dbContext.AddSqlData(sql);

            return data;
        }

        public bool RemoveEntity(PlanModel entity)
        {
            //const string sql = $@"DELETE FROM [Plan] WHERE [Plan_ID] = @PlanId";
            var sql = $@"DELETE FROM [Plans] WHERE [Plan_ID] = {entity.Id}";

            var data = _dbContext.RemoveSqlData(sql);

            return data;
        }

        public bool RemoveEntity(string id)
        {
            const string sql = "DELETE * FROM [Plans] WHERE [Plan_ID] = @PlanId";

            using var data = _dbContext.ReadSqlData(sql, (Name: "@PlanId", Value: id));

            return data != null;
        }

        public bool UpdateEntity(PlanModel entity)
        {
            const string sql = $@"UPDATE [Plans] set [Plan_Name] = @PlanName where [Plan_ID] = @PlanId";

            var data = _dbContext.UpdateSqlData(sql, (Name: "@PlanId", Value: entity));

            return data;
        }
    }
}