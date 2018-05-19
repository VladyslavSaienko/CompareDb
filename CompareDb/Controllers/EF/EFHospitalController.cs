using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompareDb.Interfaces.EF;
using CompareDb.Managers.EF;
using CompareDb.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CompareDb.Controllers.EF
{
    [Route("api/ef/hospital")]
    public class EFHospitalController : Controller
    {
        public IEFHospitalManager HospitalManager { get; }

        public EFHospitalController(IEFHospitalManager hospitalManager)
        {
            HospitalManager = hospitalManager;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Insert([FromBody]GenerateItemsRequest request)
        {
            return Ok(await HospitalManager.GenerateHospitalsAsync(request));
        }
    }
}
