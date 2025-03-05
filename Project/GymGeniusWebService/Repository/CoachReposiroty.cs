using GymGeniusWebService.DB;
using GymGeniusWebService.Factory_Methods;
using System.Data;
using ViewModels.Models;

namespace GymGeniusWebService.Repository
{
    public class CoachRepository : Repository, Repository<Coach_Model>
    {
        public CoachRepository(DBContext dbContext) : base(dbContext)
        {
        }

        // Create a Coach
        public bool Create(Coach_Model entity)
        {
            string sql = $@"Insert into Coach(Coach_Name) values(@Coach_Name)";
            base.dbContext.AddParameters("@Coach_Name", entity.CoachName);
            return dbContext.Insert(sql);
        }

        public bool Update(Coach_Model model)
        {
            string sql = $@"Update Coach set Coach_Name = @Coach_Name where Coach_ID = @Coach_ID";
            base.dbContext.AddParameters("@Coach_Name", model.CoachName);
            base.dbContext.AddParameters("@Coach_ID", model.Id.ToString());
            return dbContext.Update(sql);
        }

        // Delete a Coach
        public bool Delete(Coach_Model entity)
        {
            string sql = $@"Delete from Coach where Coach_ID = @Coach_ID";
            base.dbContext.AddParameters("@Coach_ID", entity.Id.ToString());
            return dbContext.Delete(sql);
        }

        public bool Delete(string id)
        {
            string sql = $@"Delete from Coach where Coach_ID = @Coach_ID";
            base.dbContext.AddParameters("@Coach_ID", id);
            return dbContext.Delete(sql);
        }

        public Coach_Model GetCoachID(string id, CoachCreator CoachCreator)
        {
            string sql = $@"select * from Coach where Coach_ID = @Coach_ID";
            base.dbContext.AddParameters("@Coach_ID", id);
            using (IDataReader dataReader = base.dbContext.Read(sql))
            {
                return modelfactory.CoachCreator.CreateModel(dataReader);
            }
        }

        public IEnumerable<Coach_Model> GetAll()
        {
            List<Coach_Model> Coach = new List<Coach_Model>();
            string sql = $@"select * from Coach";
            using (IDataReader dataReader = this.dbContext.Read(sql))
            {
                while (dataReader.Read())
                {
                    Coach.Add(this.modelfactory.CoachCreator.CreateModel(dataReader));
                }
            }
            return Coach;
        }

        public Coach_Model GetById(string id)
        {
            string sql = $@"select * from Coach where Coach_ID = @Coach_ID";
            base.dbContext.AddParameters("@Coach_ID", id);
            using (IDataReader dataReader = this.dbContext.Read(sql))
            {
                if (dataReader.Read())
                {
                    return this.modelfactory.CoachCreator.CreateModel(dataReader);
                }
                return null;
            }
        }
    }
}
