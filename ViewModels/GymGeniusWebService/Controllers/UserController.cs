using GymGeniusWebService.Repository;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Models;

namespace GymGeniusWebService.Controllers
{
    [Route("api/[Controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        DBContext DBContext;
        GymGeniusUnitofWorkRep GymGeniusUnitofWork;
        public UserController()
        {
            this.DBContext = DBContext.GetInstance();
            this.GymGeniusUnitofWork = new GymGeniusUnitofWorkRep(DBContext);
        }
        [HttpPost]
        public bool AddnewUser(People_Model people) // add a new user
        {
            try
            {
                this.DBContext.OpenConnection();
                return GymGeniusUnitofWork.PeopleRepository.Create(people);
            }
            catch
            {
                return false;
            }
            finally
            {
                this.DBContext.CloseConnection();
            }

        }
        [HttpGet]
        public People_Model? LoginUser(string username, string password) // login the user using pass and username
        {
            try
            {
                this.DBContext.OpenConnection();
                return GymGeniusUnitofWork.PeopleRepository.GetByNameAndPassword(username, password);
            }
            catch
            {
                return null;
            }
            finally
            {
                this.DBContext.CloseConnection();
            }

        }
        [HttpGet]
        public bool UpdateUser(People_Model people) // update the user
        {
            try
            {
                this.DBContext.OpenConnection();
                return GymGeniusUnitofWork.PeopleRepository.Update(people);
            }
            catch
            {
                return false;
            }
            finally
            {
                this.DBContext.CloseConnection();
            }
        }
        [HttpPost]
        public bool? AddNewPlan(Plan_Model plans) // add a plan to the user
        {
            try
            {
                this.DBContext.OpenConnection();
                return GymGeniusUnitofWork.PlanRepository.Create(plans);
            }
            catch
            {
                return false;
            }
            finally
            {
                this.DBContext.CloseConnection();
            }
        }
        [HttpGet]
        public Plan_Model? GetPlan(string id) // get to see the plan of the guy 
        {
            try
            {
                this.DBContext.OpenConnection();
                return GymGeniusUnitofWork.PlanRepository.GetById(id);
            }
            catch
            {
                return null;
            }
            finally
            {
                this.DBContext.CloseConnection();
            }
        }
    
    }
}
