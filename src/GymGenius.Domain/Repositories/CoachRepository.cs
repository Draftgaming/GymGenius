using GymGenius.DataAccess;
using GymGenius.DataAccess.Models;
using GymGenius.Domain.Abstraction;
using GymGenius.Domain.Extensions;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GymGenius.Domain.Repositories
{
    public class CoachRepository(IDbContext IDbContext) : ICoachRepository
    {
        private readonly IDbContext _dbContext = IDbContext;

        public IEnumerable<CoachModel> Get()
        {
            const string sql = "SELECT * FROM [Coach]";

            return _dbContext.ReadSqlData(sql).GetEntities<CoachModel>();
        }

        public CoachModel Get(string id)
        {
            const string sql = "SELECT * FROM [Coach] WHERE [Coach_ID] = @coachId";

            return _dbContext
                .ReadSqlData(sql, (Name: "@coachId", Value: id))
                .GetEntities<CoachModel>()
                .FirstOrDefault() ?? new CoachModel();
        }

        public bool NewEntity(CoachModel entity)
        {
            string sql = $"INSERT INTO [Coach] ([Coach_Name]) VALUES ('{entity.CoachName}');";

            var data = _dbContext.AddSqlData(sql);
            
            return data;
        }

        public bool RemoveEntity(CoachModel entity)
        {
            //const string sql = $@"DELETE FROM [Coach] WHERE [Coach_ID] = @coachid";
            var sql = $@"DELETE FROM [Coach] WHERE [Coach_ID] = {entity.Id}";

            var data = _dbContext.RemoveSqlData(sql);
            
            return data;
        }

        public bool RemoveEntity(string id)
        {
            const string sql = "DELETE * FROM [Coach] WHERE [Coach_ID] = @coachId";

            var data = _dbContext.RemoveSqlData(sql, (Name: "@coachId", Value: id));

            return data;
        }

        public bool UpdateEntity(CoachModel entity)
        {
            const string sql = @"UPDATE [Coach] 
                         SET [Coach_Name] = @CoachName
                         WHERE [Coach_ID] = @CoachId";
            ;

            var data = _dbContext.UpdateSqlData(sql,
        (Name: "@CoachId", Value: entity.Id),
        (Name: "@CoachName", Value: entity.CoachName));


            return data;
        }
    }
}
