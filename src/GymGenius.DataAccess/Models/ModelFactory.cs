using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymGenius.DataAccess.Models
{
    public static class ModelFactory
    {
        public static T NewModel<T>(params object[] args) where T : ModelBase
        {
            return (T)Activator.CreateInstance(typeof(T), args);
        }
    }
}
