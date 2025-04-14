using GymGenius.DataAccess;
using GymGenius.DataAccess.Models;
using GymGenius.Domain.Abstraction;
using GymGenius.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GymGenius.Domain.Repositories
{
    public class PeopleRepository(IDbContext IDbContext) : IPeopleRepository
    {
        private readonly IDbContext _dbContext = IDbContext;

        public IEnumerable<PeopleModel> Get()
        {
            const string sql = "SELECT * FROM [Peoples]";

            return _dbContext.ReadSqlData(sql).GetEntities<PeopleModel>();
        }

        public PeopleModel Get(string id)
        {
            const string sql = "SELECT * FROM [Peoples] WHERE [People_ID] = @peopleId";

            return _dbContext
                .ReadSqlData(sql, (Name: "@peopleId", Value: id))
                .GetEntities<PeopleModel>()
                .FirstOrDefault() ?? new PeopleModel();
        }

        public bool NewEntity(PeopleModel entity)
        {
            string sql = $"INSERT INTO [Peoples] ([People_Name]) VALUES ('{entity.PeopleName}');";

            var data = _dbContext.AddSqlData(sql);

            return data;
        }

        public bool RemoveEntity(PeopleModel entity)
        {
           
            var sql = $"DELETE FROM [Peoples] WHERE [People_ID] = {entity.Id}";

            return _dbContext.RemoveSqlData(sql);
        }

        public bool RemoveEntity(string id)
        {
            const string sql = "DELETE * FROM [Peoples] WHERE [People_ID] = @peopleId";

            return _dbContext.RemoveSqlData(sql, (Name: "@peopleId", Value: id));
        }

        public bool UpdateEntity(PeopleModel entity)
        {
            var sql = "UPDATE [Peoples] " +
                $"SET [People_Name] = '{entity.PeopleName}' " +
                "WHERE [People_Id] = @PeopleId";

            return _dbContext.UpdateSqlData(
                sql,
                (Name: "@PeopleId", Value: entity.PeopleId));
        }
    }
}

