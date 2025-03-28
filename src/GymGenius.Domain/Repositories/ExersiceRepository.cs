﻿using GymGenius.DataAccess.Models;
using GymGenius.DataAccess;
using GymGenius.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymGenius.Domain.Repositories
{
    public class ExersiceRepository(IDbContext IDbContext) : IExerciseRepository
    {
        private readonly IDbContext _IDbContext = IDbContext;

        public IEnumerable<ExersiceModel> Get()//get all 
        {
            const string sql = "SELECT * FROM [Exersice]";

            using var data = _IDbContext.ReadSqlData(sql);

            return [];
        }

        public ExersiceModel Get(string id)
        {
            const string sql = "SELECT * FROM [Exersice] WHERE [Exersice_ID] = @ExersiceId";

            using var data = _IDbContext.ReadSqlData(sql, (Name: "@ExersiceId", Value: id));

            return ModelFactory.NewModel<ExersiceModel>();
        }

        public bool NewEntity(ExersiceModel entity)
        {
            string sql = $@"INSERT INTO [Exersice] WHERE [Exersice_ID] = @ExersiceId";

            var data = _IDbContext.AddSqlData(sql, (Name: "@ExersiceId", Value: entity));

            return data;
        }

        public bool RemoveEntity(ExersiceModel entity)
        {
            //const string sql = $@"DELETE FROM [Exersice] WHERE [Exersice_ID] = @ExersiceId";
            var sql = $@"DELETE FROM [Exersice] WHERE [Exersice_ID] = {entity.Id}";

            var data = _IDbContext.RemoveSqlData(sql);

            return data;
        }

        public bool RemoveEntity(string id)
        {
            const string sql = "SELECT * FROM [Exersice] WHERE [Exersice_ID] = @ExersiceId";

            using var data = _IDbContext.ReadSqlData(sql, (Name: "@ExersiceId", Value: id));

            return data != null;
        }

        public bool UpdateEntity(ExersiceModel entity)
        {
            const string sql = $@"UPDATE [Exersice] set [Exersice_Name] = @ExersiceName where [Exersice_ID] = @ExersiceId";

            var data = _IDbContext.UpdateSqlData(sql, (Name: "@ExersiceId", Value: entity));

            return data;
        }
    }
}