using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompareDb.Managers.EF;
using CompareDb.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CompareDb.Controllers.EF
{
    [Route("api/ef/patient")]
    public class PatientController:Controller
    {
        public IPatientManager PatientManager { get; }

        public PatientController(IPatientManager patientManager)
        {
            PatientManager = patientManager;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Insert([FromBody]GenerateItemsRequest request)
        {
            return Ok(await PatientManager.GenerateUsersAsync(request));
        }
    }
}
