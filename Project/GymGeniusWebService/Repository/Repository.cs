using GymGeniusWebService.DB;
using GymGeniusWebService.Factory_Methods;
using ViewModels.Models;
namespace GymGeniusWebService.Repository
{
    public abstract class Repository
    {
        //actions on database
        protected DBContext dbContext;
        //actions Factorymodel
        protected ModelFactory modelfactory;
        public Repository(DBContext dBContext)
        {
            dbContext = dBContext;
            modelfactory = ModelFactory.getInstance();
        }
        protected string GetLastInsertedId()
        {
            string sql = "select @@Identity";
            return this.dbContext.ReadValue(sql).ToString();
        }


    }

}
