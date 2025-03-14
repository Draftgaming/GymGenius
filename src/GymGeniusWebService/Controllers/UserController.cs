using GymGeniusWebService.Factory_Methods;
using GymGeniusWebService.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Formats.Asn1;
using System.Globalization;
using System.Xml.Linq;
using ViewModels.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GymGeniusWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        DBContext dBContext;
        // Get access for the DB
        GymGeniusUnitofWork gymgeniusUoW;
        //The Creator of the Models
        public UserController()
        {
            this.dBContext = DBContext.GetInstance();
            this.gymgeniusUoW = new GymGeniusUnitofWork(dBContext);
        }

        [HttpPost("AddNewUser")]
        public bool AddNewUser(string password, string name, string weight, string age, string email, string number, string Coach,string Plan)
        {
            try
            {
                this.dBContext.OpenConnection();
                People_Model pm = new People_Model() { PeoplePassword = password, PeopleWeight = weight, PeopleName = name,PeopleEmail = email,PeopleAge = age , PeopleNumber = number};
                return gymgeniusUoW.PeopleRepository.Create(pm);

            }
            catch
            {
                return false;
            }
            finally
            {
                this.dBContext.CloseConnection();
            }
        }


        [HttpPost("UpdateUser")]
        public bool UpdateUser(string password, string name, string weight, string age, string email, string number)
        {
        http://GymGeniusWebService/api/UserController/UpdateUser
            try
            {
                this.dBContext.OpenConnection();
                People_Model pm = new People_Model() { PeoplePassword = password, PeopleWeight = weight, PeopleName = name, PeopleEmail = email, PeopleAge = age, PeopleNumber = number };

                return gymgeniusUoW.PeopleRepository.Update(pm);

            }
            catch
            {
                return false;
            }
            finally
            {
                this.dBContext.CloseConnection();
            }
        }


        [HttpGet("LoginUser")]
        public People_Model LoginUser(string password, string name)
        {
        http://GymGeniusWebService/api/UserController/AddNewUser
            try
            {
                this.dBContext.OpenConnection();
                
                return gymgeniusUoW.PeopleRepository.GetPeopleLogin(name,password);

            }
            catch
            {
                return null;
            }
            finally
            {
                this.dBContext.CloseConnection();
            }
        }


        [HttpPost("AddPlan")]
        public bool AddPlan(string planexersice , string planName )
        {
        http://GymGeniusWebService/api/UserController/AddNewUser
            try
            {
                this.dBContext.OpenConnection();
                Plan_Model pm = new Plan_Model() { PlanExercise = planexersice, PlanName = planName};
                return gymgeniusUoW.PlanRepository.Create(pm);

            }
            catch
            {
                return false;
            }
            finally
            {
                this.dBContext.CloseConnection();
            }

        }

    }
}
