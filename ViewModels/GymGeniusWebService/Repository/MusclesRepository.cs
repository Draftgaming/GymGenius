using GymGeniusWebService.DB;
using GymGeniusWebService.Factory_Methods;
using System.Data;
using ViewModels.Models;

namespace GymGeniusWebService.Repository
{
    public class MusclesRepository : Repository, IRepository<Muscles_Model>
    {
        public MusclesRepository(DBContext dbContext) : base(dbContext)
        {
        }

        // Create a Person
        public bool Create(Muscles_Model entity)
        {
            string sql = $@"Insert into Muscles_Model(Muscles_Name, Muscles_Description);
                            values(@Muscles_Name, @Muscles_Description)";
            base.dbContext.AddParameters("@Muscles_Name", entity.MusclesName);
            base.dbContext.AddParameters("@Muscles_Description", entity.MusclesDescription);
            return dbContext.Insert(sql);
        }

        // Update a Person
        public bool Update(Muscles_Model model)
        {
            string sql = $@"Update Muscles_Model 
                            set Muscles_Name = @Muscles_Name, 
                                Muscles_Description = @Muscles_Description, 
                            where Muscles_ID = @Muscles_ID";
            base.dbContext.AddParameters("@Muscles_Name", model.MusclesName);
            base.dbContext.AddParameters("@Muscles_Description", model.MusclesDescription);
            base.dbContext.AddParameters("@Muscles_ID", model.Id.ToString());
            return dbContext.Update(sql);
        }

        // Delete a Person by entity
        public bool Delete(Muscles_Model entity)
        {
            string sql = $@"Delete from Muscles_Model where Muscles_ID = @Muscles_ID";
            base.dbContext.AddParameters("@Muscles_ID", entity.Id.ToString());
            return dbContext.Delete(sql);
        }

        // Delete a Person by ID
        public bool Delete(string id)
        {
            string sql = $@"Delete from Muscles_Model where Muscles_ID = @Muscles_ID";
            base.dbContext.AddParameters("@Muscles_ID", id);
            return dbContext.Delete(sql);
        }

        // Get a Person by ID using a Creator
        public Muscles_Model GetMusclesID(string id, MusclesCreator MusclesCreator)
        {
            string sql = $@"select * from Muscles_Model where Muscles_ID = @Muscles_ID";
            base.dbContext.AddParameters("@Muscles_ID", id);
            using (IDataReader dataReader = base.dbContext.Read(sql))
            {
                return modelfactory.MusclesCreator.CreateModel(dataReader);
            }
        }

        // Get all Muscles
        public IEnumerable<Muscles_Model> GetAll()
        {
            List<Muscles_Model> Muscles = new List<Muscles_Model>();
            string sql = $@"select * from Muscles_Model";
            using (IDataReader dataReader = this.dbContext.Read(sql))
            {
                while (dataReader.Read())
                {
                    Muscles.Add(this.modelfactory.MusclesCreator.CreateModel(dataReader));
                }
            }
            return Muscles;
        }

        // Get a Person by ID
        public Muscles_Model GetById(string id)
        {
            string sql = $@"select * from Muscles_Model where Muscles_ID = @Muscles_ID";
            base.dbContext.AddParameters("@Muscles_ID", id);
            using (IDataReader dataReader = this.dbContext.Read(sql))
            {
                if (dataReader.Read())
                {
                    return this.modelfactory.MusclesCreator.CreateModel(dataReader);
                }
                return null;
            }
        }
    }
}
