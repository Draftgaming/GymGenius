using GymGenius.DataAccess;
using GymGenius.DataAccess.Models;
using GymGenius.Domain.Abstraction;

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
        private readonly IDbContext _IDbContext = IDbContext;

        public IEnumerable<CoachModel> Get()//get all 
        {
            const string sql = "SELECT * FROM [Coach]";

            using var data = _IDbContext.ReadSqlData(sql);

            return [];
        }

        public CoachModel Get(string id) 
        {
            const string sql = "SELECT * FROM [Coach] WHERE [Coach_ID] = @coachId";

            using var data = _IDbContext.ReadSqlData(sql, (Name: "@coachId", Value: id));

            return ModelFactory.NewModel<CoachModel>();
        }

        public bool NewEntity(CoachModel entity)
        {
            string sql = $@"INSERT INTO [Coach] WHERE [Coach_ID] = @coachId";

            var data = _IDbContext.AddSqlData(sql, (Name: "@coachId", Value: entity));
            
            return data;
        }

        public bool RemoveEntity(CoachModel entity)
        {
            //const string sql = $@"DELETE FROM [Coach] WHERE [Coach_ID] = @coachid";
            var sql = $@"DELETE FROM [Coach] WHERE [Coach_ID] = {entity.Id}";

            var data = _IDbContext.RemoveSqlData(sql);
            
            return data;
        }

        public bool RemoveEntity(string id)
        {
            const string sql = "SELECT * FROM [Coach] WHERE [Coach_ID] = @coachId";

            using var data = _IDbContext.ReadSqlData(sql, (Name: "@coachId", Value: id));

            return data != null;
        }

        public bool UpdateEntity(CoachModel entity)
        {
            const string sql = $@"UPDATE [Coach] set [Coach_Name] = @CoachName where [Coach_ID] = @CoachId";
            
            var data = _IDbContext.UpdateSqlData(sql, (Name: "@CoachId", Value: entity));
            
            return data;
        }
    }
}
