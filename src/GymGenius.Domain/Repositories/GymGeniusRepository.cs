using GymGenius.DataAccess;
using GymGenius.Domain.Abstraction;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymGenius.Domain.Repositories
{
    public class GymGeniusRepository(IDbContext dbContext) : IGymGeniusRepository
    {
        public IEnumerable<object> Get()
        {
            throw new NotImplementedException();
        }

        public object Get(string id)
        {
            throw new NotImplementedException();
        }

        public bool NewEntity(object entity)
        {
            throw new NotImplementedException();
        }

        public bool RemoveEntity(object entity)
        {
            throw new NotImplementedException();
        }

        public bool RemoveEntity(string id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEntity(object entity)
        {
            throw new NotImplementedException();
        }
    }
}
