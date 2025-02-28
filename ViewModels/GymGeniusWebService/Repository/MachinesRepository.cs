using GymGeniusWebService.DB;
using GymGeniusWebService.Factory_Methods;
using System.Data;
using ViewModels.Models;

namespace GymGeniusWebService.Repository
{
    public class MachinesRepository : Repository, IRepository<Machines_Model>
    {
        public MachinesRepository(DBContext dbContext) : base(dbContext)
        {
        }

        // Create a Person
        public bool Create(Machines_Model entity)
        {
            string sql = $@"Insert into Machines_Model(Machine_Name, Machine_Description, Machine_Image)
                            values(@Machine_Name, @Machine_Description, @Machine_Image)";
            base.dbContext.AddParameters("@Machine_Name", entity.MachineName);
            base.dbContext.AddParameters("@Machine_Description", entity.MachineDescription);
            base.dbContext.AddParameters("@Machine_Image", entity.MachineImage);
            
            return dbContext.Insert(sql);
        }

        // Update a Person
        public bool Update(Machines_Model model)
        {
            string sql = $@"Update Machines_Model 
                            set Machine_Name = @Machine_Name, 
                                Machine_Description = @Machine_Description, 
                                Machine_Image = @Machine_Image, 
                               
                            where Machine_ID = @Machine_ID";
            base.dbContext.AddParameters("@Machine_Name", model.MachineName);
            base.dbContext.AddParameters("@Machine_Description", model.MachineDescription);
            base.dbContext.AddParameters("@Machine_Image", model.MachineImage);
            
            base.dbContext.AddParameters("@Machine_ID", model.Id.ToString());
            return dbContext.Update(sql);
        }

        // Delete a Person by entity
        public bool Delete(Machines_Model entity)
        {
            string sql = $@"Delete from Machines_Model where Machine_ID = @Machine_ID";
            base.dbContext.AddParameters("@Machine_ID", entity.Id.ToString());
            return dbContext.Delete(sql);
        }

        // Delete a Person by ID
        public bool Delete(string id)
        {
            string sql = $@"Delete from Machines_Model where Machine_ID = @Machine_ID";
            base.dbContext.AddParameters("@Machine_ID", id);
            return dbContext.Delete(sql);
        }

        // Get a Person by ID using a Creator
        public Machines_Model GetMachinesID(string id, MachinesCreator MachineCreator)
        {
            string sql = $@"select * from Machines_Model where Machine_ID = @Machine_ID";
            base.dbContext.AddParameters("@Machine_ID", id);
            using (IDataReader dataReader = base.dbContext.Read(sql))
            {
                return modelfactory.MachinesCreator.CreateModel(dataReader);
            }
        }

        // Get all Machines
        public IEnumerable<Machines_Model> GetAll()
        {
            List<Machines_Model> Machines = new List<Machines_Model>();
            string sql = $@"select * from Machine_Model";
            using (IDataReader dataReader = this.dbContext.Read(sql))
            {
                while (dataReader.Read())
                {
                    Machines.Add(this.modelfactory.MachinesCreator.CreateModel(dataReader));
                }
            }
            return Machines;
        }

        // Get a Person by ID
        public Machines_Model GetById(string id)
        {
            string sql = $@"select * from Machines_Model where Machine_ID = @Machine_ID";
            base.dbContext.AddParameters("@Machine_ID", id);
            using (IDataReader dataReader = this.dbContext.Read(sql))
            {
                if (dataReader.Read())
                {
                    return this.modelfactory.MachinesCreator.CreateModel(dataReader);
                }
                return null;
            }
        }
    }
}
