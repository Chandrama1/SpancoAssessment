using Dapper;
using DataAccess.Interfaces;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Data;

namespace DataAccess
{
    public class SaveData : ISaveData
    {
        private readonly IConfiguration _configuration;
        private readonly IConnectToDb _dbObj;

        public SaveData(IConfiguration configuration)
        {
            _dbObj = new ConnectToDb(configuration);
        }

        public bool SavePatientDetails(FormFields formFields)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@PatientFirstName", formFields.FirstName, DbType.String, ParameterDirection.Input);
                parameters.Add("@PatientMiddleName", formFields.MiddleName, DbType.String, ParameterDirection.Input);
                parameters.Add("@PatientLastName", formFields.LastName, DbType.String, ParameterDirection.Input);
                parameters.Add("@Gender", formFields.Gender, DbType.String, ParameterDirection.Input);
                parameters.Add("@DateOfBirth", formFields.DateOfBirth, DbType.Date, ParameterDirection.Input);
                parameters.Add("@CaseType", formFields.CaseType, DbType.String, ParameterDirection.Input);
                parameters.Add("@PoliceEnquiryRemark", formFields.PoliceEnquiryRemark, DbType.String, ParameterDirection.Input);
                parameters.Add("@PresentAddress", formFields.PresentAddress, DbType.String, ParameterDirection.Input);
                parameters.Add("@PermanentAddress", formFields.PermanentAddress, DbType.String, ParameterDirection.Input);
                parameters.Add("@RowCount", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                return _dbObj.ExecuteSP("SavePatientDetails", parameters);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
