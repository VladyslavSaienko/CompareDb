using System.Threading.Tasks;
using CompareDb.Interfaces.MongoDB;
using CompareDb.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CompareDb.Controllers.MongoDB
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
