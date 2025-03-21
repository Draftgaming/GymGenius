﻿using GymGenius.DataAccess;
using GymGenius.DataAccess.Models;
using GymGenius.Domain.Abstraction;
using System;
using System.Collections.Generic;

namespace GymGenius.Domain.Repositories
{
    public class PeopleRepository(IDbContext dbContext) : IPeopleRepository
    {
        private readonly IDbContext _dbContext = dbContext;

        public IEnumerable<PeopleModel> Get()//get all 
        {
            const string sql = "SELECT * FROM [People]";

            using var data = _dbContext.ReadSqlData(sql);

            return [];
        }

        public PeopleModel Get(string id)
        {
            const string sql = "SELECT * FROM [People] WHERE [People_ID] = @peopleId";

            using var data = _dbContext.ReadSqlData(sql, (Name: "@peopleId", Value: id));

            return ModelFactory.NewModel<PeopleModel>();
        }

        public bool NewEntity(PeopleModel entity)
        {
            string sql = $@"INSERT INTO [People] WHERE [People_ID] = @peopleId";

            var data = _dbContext.AddSqlData(sql, (Name: "@peopleId", Value: entity));

            return data;
        }

        public bool RemoveEntity(PeopleModel entity)
        {
            //const string sql = $@"DELETE FROM [People] WHERE [People_ID] = @peopleId";
            var sql = $@"DELETE FROM [People] WHERE [People_ID] = {entity.Id}";

            var data = _dbContext.RemoveSqlData(sql);

            return data;
        }

        public bool RemoveEntity(string id)
        {
            const string sql = "SELECT * FROM [People] WHERE [People_ID] = @peopleId";

            using var data = _dbContext.ReadSqlData(sql, (Name: "@peopleId", Value: id));

            return data != null;
        }

        public bool UpdateEntity(PeopleModel entity)
        {
            const string sql = $@"UPDATE [People] set [People_Name] = @PeopleName where [People_ID] = @peopleId";
            var data = _dbContext.UpdateSqlData(sql, (Name: "@peopleId", Value: entity));
            return data;
        }
    }
}
