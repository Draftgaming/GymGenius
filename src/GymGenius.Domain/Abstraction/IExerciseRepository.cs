using GymGenius.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymGenius.Domain.Abstraction
{
    public interface IExerciseRepository: IRepository<ExersiceModel>
    {
    }
}
