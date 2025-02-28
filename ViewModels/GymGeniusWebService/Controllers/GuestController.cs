using GymGeniusWebService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GymGeniusWebService.Controllers
{
    public class GuestController : Controller
    {
        DBContext dbContext;
        GymGeniusUnitofWorkRep GymGeniusUnitofWork;
    }
}
