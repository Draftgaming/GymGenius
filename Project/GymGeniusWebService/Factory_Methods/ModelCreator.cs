using System.Data;

namespace GymGeniusWebService.Factory_Methods
{
    //the base of the model creation
    public interface ModelCreator<T>
    {
        T CreateModel(IDataReader src);
    }
}
