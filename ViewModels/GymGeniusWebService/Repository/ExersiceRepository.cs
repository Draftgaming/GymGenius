using GymGeniusWebService.DB;
using GymGeniusWebService.Factory_Methods;
using System.Data;
using ViewModels.Models;

namespace GymGeniusWebService.Repository
{
    public class ExersiceRepository : Repository, IRepository<Exersice_Model>
    {
        public ExersiceRepository(DBContext dbContext) : base(dbContext)
        {
        }

        // Create a Person
        public bool Create(Exersice_Model entity)
        {
            string sql = $@"Insert into Exersice_Model(Exersice_Name)";
            base.dbContext.AddParameters("@Exersice_Name", entity.ExersiceName);
            return dbContext.Insert(sql);
        }

        // Update a Person
        public bool Update(Exersice_Model model)
        {
            string sql = $@"Update Exersice_Model 
                            set Exersice_Name = @Exersice_Name,
                            where Exersice_ID = @Exersice_ID";
            base.dbContext.AddParameters("@Exersice_Name", model.ExersiceName);
            base.dbContext.AddParameters("@Exersice_ID", model.Id.ToString());
            return dbContext.Update(sql);
        }

        // Delete a Person by entity
        public bool Delete(Exersice_Model entity)
        {
            string sql = $@"Delete from Exersice_Model where Exersice_ID = @Exersice_ID";
            base.dbContext.AddParameters("@Exersice_ID", entity.Id.ToString());
            return dbContext.Delete(sql);
        }

        // Delete a Person by ID
        public bool Delete(string id)
        {
            string sql = $@"Delete from Exersice_Model where Exersice_ID = @Exersice_ID";
            base.dbContext.AddParameters("@Exersice_ID", id);
            return dbContext.Delete(sql);
        }

        // Get a Person by ID using a Creator
        public Exersice_Model GetExersiceID(string id, ExersiceCreator ExersiceCreator)
        {
            string sql = $@"select * from Exersice_Model where Exersice_ID = @Exersice_ID";
            base.dbContext.AddParameters("@Exersice_ID", id);
            using (IDataReader dataReader = base.dbContext.Read(sql))
            {
                return modelfactory.ExersiceCreator.CreateModel(dataReader);
            }
        }

        // Get all Exersice
        public IEnumerable<Exersice_Model> GetAll()
        {
            List<Exersice_Model> Exersice = new List<Exersice_Model>();
            string sql = $@"select * from Exersice_Model";
            using (IDataReader dataReader = this.dbContext.Read(sql))
            {
                while (dataReader.Read())
                {
                    Exersice.Add(this.modelfactory.ExersiceCreator.CreateModel(dataReader));
                }
            }
            return Exersice;
        }

        // Get a Person by ID
        public Exersice_Model GetById(string id)
        {
            string sql = $@"select * from Exersice_Model where Exersice_ID = @Exersice_ID";
            base.dbContext.AddParameters("@Exersice_ID", id);
            using (IDataReader dataReader = this.dbContext.Read(sql))
            {
                if (dataReader.Read())
                {
                    return this.modelfactory.ExersiceCreator.CreateModel(dataReader);
                }
                return null;
            }
        }
    }
}
