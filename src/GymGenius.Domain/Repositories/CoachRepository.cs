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


//TODO To put SQL into these reposetories and make the rest of the repos
namespace GymGenius.Domain.Repositories
{
    public class CoachRepository(IDbContext dbContext) : ICoachRepository
    {
        private readonly IDbContext _dbContext = dbContext;

        public IEnumerable<CoachModel> Get()//get all 
        {
            const string sql = "SELECT * FROM [Coach]";

            using var data = _dbContext.ReadSqlData(sql);

            return [];
        }

        public CoachModel Get(string id) 
        {
            const string sql = "SELECT * FROM [Coach] WHERE [Coach_ID] = @coachId";

            using var data = _dbContext.ReadSqlData(sql, (Name: "@coachId", Value: id));

            return ModelFactory.NewModel<CoachModel>();
        }

        public bool NewEntity(CoachModel entity)
        {
            string sql = $@"INSERT INTO [Coach] WHERE [Coach_ID] = @coachId";

            var data = _dbContext.AddSqlData(sql, (Name: "@coachId", Value: entity));
            
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
            const string sql = "SELECT * FROM [Coach] WHERE [Coach_ID] = @coachId";

            using var data = _dbContext.ReadSqlData(sql, (Name: "@coachId", Value: id));

            return data != null;
        }

        public bool UpdateEntity(CoachModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
