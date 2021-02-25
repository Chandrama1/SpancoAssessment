using Models;

namespace DataAccess.Interfaces
{
    public interface ISaveData
    {
        bool SavePatientDetails(FormFields formFields);
    }
}
