using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompareDb.Managers.MongoDB;
using CompareDb.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CompareDb.Controllers
{
    [Route("api/contract")]
    public class ContractController : Controller
    {
        public IContractManager ContractManager { get; }

        public ContractController(IContractManager contractManager)
        {
            ContractManager = contractManager;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Insert([FromBody]GenerateItemsRequest request)
        {
            return Ok(await ContractManager.GenerateContractsAsync(request));
        }
    }
}
