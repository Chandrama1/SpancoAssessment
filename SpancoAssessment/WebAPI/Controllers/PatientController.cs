using DataAccess;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Models;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/Patient")]
    public class PatientController : ControllerBase
    {
        private readonly IService _IService;

        private readonly ILogger<PatientController> _logger;

        public PatientController(ILogger<PatientController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _IService = new Service(configuration);
        }

        [Route("GetData")]
        [HttpGet]
        public string GetData()
        {
            return "hi";
        }

        [Route("SavePatientDetails")]
        [HttpPost]
        public bool SavePatientDetails([FromBody] FormFields formFields)
        {
            bool isSuccess = false;
            isSuccess = _IService.SavePatientDetails(formFields);
            return isSuccess;
        }
    }
}
