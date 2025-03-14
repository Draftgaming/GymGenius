using System.Linq;
using GymGeniusWebService.Repository;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Models;
using ViewModels.ViewModels;

namespace GymGeniusWebService.Controllers
{
    [Route("api/[Controller]/[action]")]
    [ApiController]
    public class GuestController : Controller
    {
        private readonly DBContext _context;
        private readonly GymGeniusUnitofWork _gymGeniusUnitofWork;

        public GuestController()
        {
            _context = DBContext.GetInstance();
            _gymGeniusUnitofWork = new GymGeniusUnitofWork(_context);
        }

        [HttpGet]
        public Machines_Model GetMachinesCatalogViewModel(int Pagenum = 1, int Machinesperpage = 9, string? muscle = null, string? machine = null)
        {
            Machines_Model machineModel = null;
            _context.OpenConnection();
            if (muscle != null)
            {
                var a = _gymGeniusUnitofWork
                    .MachinesRepository
                    .GetAll()
                    .FirstOrDefault(i => i.Muscles.Any(m => m.MusclesName == muscle));
            }

            return machineModel ?? new Machines_Model();
        }
    }
}
