using System.Threading.Tasks;
using CompareDb.Interfaces.MongoDB;
using CompareDb.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CompareDb.Controllers.MongoDB
{
    [Route("api/labor")]
    public class LaborController : Controller
    {
        public ILaborManager LaborManager { get; }

        public LaborController(ILaborManager laborManager)
        {
            LaborManager = laborManager;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Insert([FromBody]GenerateLaborsRequest request)
        {
            return Ok(await LaborManager.GenerateDepartmentsAsync(request));
        }
    }
}
