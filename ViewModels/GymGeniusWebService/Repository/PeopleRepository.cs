﻿using GymGeniusWebService.DB;
using GymGeniusWebService.Factory_Methods;
using System.Data;
using ViewModels.Models;

namespace GymGeniusWebService.Repository
{
    public class PeopleRepository : Repository, IRepository<People_Model>
    {
        public PeopleRepository(DBContext dbContext) : base(dbContext)
        {
        }

        // Create a Person
        public bool Create(People_Model entity)
        {
            string sql = $@"Insert into People_Model(People_Name, People_Number, People_Weight, People_Age, People_Password, People_Email) 
                            values(@People_Name, @People_Number, @People_Weight, @People_Age, @People_Password, @People_Email)";
            base.dbContext.AddParameters("@People_Name", entity.PeopleName);
            base.dbContext.AddParameters("@People_Number", entity.PeopleNumber);
            base.dbContext.AddParameters("@People_Weight", entity.PeopleWeight);
            base.dbContext.AddParameters("@People_Age", entity.PeopleAge);
            base.dbContext.AddParameters("@People_Password", entity.PeoplePassword);
            base.dbContext.AddParameters("@People_Email", entity.PeopleEmail);
            return dbContext.Insert(sql);
        }

        // Update a Person
        public bool Update(People_Model model)
        {
            string sql = $@"Update People_Model 
                            set People_Name = @People_Name, 
                                People_Number = @People_Number, 
                                People_Weight = @People_Weight, 
                                People_Age = @People_Age, 
                                People_Password = @People_Password, 
                                People_Email = @People_Email 
                            where People_ID = @People_ID";
            base.dbContext.AddParameters("@People_Name", model.PeopleName);
            base.dbContext.AddParameters("@People_Number", model.PeopleNumber);
            base.dbContext.AddParameters("@People_Weight", model.PeopleWeight);
            base.dbContext.AddParameters("@People_Age", model.PeopleAge);
            base.dbContext.AddParameters("@People_Password", model.PeoplePassword);
            base.dbContext.AddParameters("@People_Email", model.PeopleEmail);
            base.dbContext.AddParameters("@People_ID", model.Id.ToString());
            return dbContext.Update(sql);
        }

        // Delete a Person by entity
        public bool Delete(People_Model entity)
        {
            string sql = $@"Delete from People_Model where People_ID = @People_ID";
            base.dbContext.AddParameters("@People_ID", entity.Id.ToString());
            return dbContext.Delete(sql);
        }

        // Delete a Person by ID
        public bool Delete(string id)
        {
            string sql = $@"Delete from People_Model where People_ID = @People_ID";
            base.dbContext.AddParameters("@People_ID", id);
            return dbContext.Delete(sql);
        }

        // Get a Person by ID using a Creator
        public People_Model GetPeopleID(string id, PeopleCreator peopleCreator)
        {
            string sql = $@"select * from People_Model where People_ID = @People_ID";
            base.dbContext.AddParameters("@People_ID", id);
            using (IDataReader dataReader = base.dbContext.Read(sql))
            {
                return modelfactory.PeopleCreator.CreateModel(dataReader);
            }
        }

        // Get all People
        public IEnumerable<People_Model> GetAll()
        {
            List<People_Model> people = new List<People_Model>();
            string sql = $@"select * from People_Model";
            using (IDataReader dataReader = this.dbContext.Read(sql))
            {
                while (dataReader.Read())
                {
                    people.Add(this.modelfactory.PeopleCreator.CreateModel(dataReader));
                }
            }
            return people;
        }

        // Get a Person by ID
        public People_Model GetById(string id)
        {
            string sql = $@"select * from People_Model where People_ID = @People_ID";
            base.dbContext.AddParameters("@People_ID", id);
            using (IDataReader dataReader = this.dbContext.Read(sql))
            {
                if (dataReader.Read())
                {
                    return this.modelfactory.PeopleCreator.CreateModel(dataReader);
                }
                return null;
            }
        }
        public People_Model? GetByNameAndPassword(string name, string password)
        {
            string sql = @"SELECT * FROM People_Model WHERE People_Name = @People_Name AND People_Password = @People_Password";

            base.dbContext.AddParameters("@People_Name", name);
            base.dbContext.AddParameters("@People_Password", password);

            using (IDataReader dataReader = this.dbContext.Read(sql))
            {
                if (dataReader.Read())
                {
                    return this.modelfactory.PeopleCreator.CreateModel(dataReader);
                }
                return null;
            }
        }
    }
}
