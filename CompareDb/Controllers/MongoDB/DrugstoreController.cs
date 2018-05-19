using System.Threading.Tasks;
using CompareDb.Interfaces.MongoDB;
using CompareDb.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CompareDb.Controllers.MongoDB
{
    [Route("api/drugstore")]
    public class DrugstoreController : Controller
    {
        public IDrugstoreManager DrugstoreManager { get; }

        public DrugstoreController(IDrugstoreManager drugstoreManager)
        {
            DrugstoreManager = drugstoreManager;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Insert([FromBody]GenerateItemsRequest request)
        {
            return Ok(await DrugstoreManager.GenerateDrugstoresAsync(request));
        }
    }
}
