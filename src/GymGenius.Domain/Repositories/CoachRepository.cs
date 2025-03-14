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
    public class CoachRepository(IDbContext dbContext) : ICoachRepository
    {
        private readonly IDbContext _dbContext = dbContext;

        public IEnumerable<CoachModel> Get()
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
            throw new NotImplementedException();
        }

        public bool RemoveEntity(CoachModel entity)
        {
            throw new NotImplementedException();
        }

        public bool RemoveEntity(string id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEntity(CoachModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
