using DataAccess;
using DataAccess.Interfaces;
using Microsoft.Extensions.Configuration;
using Models;
using Services.Interfaces;

namespace Services
{
    public class Service : IService
    {
        private readonly ISaveData _saveData;
        public Service(IConfiguration configuration)
        {
            _saveData = new SaveData(configuration);
        }

        public bool SavePatientDetails(FormFields formFields)
        {
            return _saveData.SavePatientDetails(formFields);
        }
    }
}
