using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompareDb.Managers.MongoDB;
using CompareDb.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CompareDb.Controllers
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
