using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompareDb.Managers.MongoDB;
using CompareDb.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CompareDb.Controllers
{
    [Route("api/hospital")]
    public class HospitalController : Controller
    {
        public IHospitalManager HospitalManager { get; }

        public HospitalController(IHospitalManager hospitalManager)
        {
            HospitalManager = hospitalManager;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Insert([FromBody]GenerateHospitalsRequest request)
        {
            return Ok(await HospitalManager.GenerateHospitalsAsync(request));
        }
    }
}
