
using ViewModels.Models;
namespace GymGeniusWebService.Repository
{
    public interface IRepository<T>
    {
        //get a single model by id
        T GetById(string id);
        //return all models 
        IEnumerable<T>GetAll();
        //create a model
        bool Create(T entity);
        //update a model
        bool Update(T entity);
        //delete a model
        bool Delete(T entity);
        //delete a model according to an id
        bool Delete(string id);
    }
}
