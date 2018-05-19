using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompareDb.Managers.MongoDB;
using CompareDb.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CompareDb.Controllers
{
    [Route("api/history")]
    public class HistoryController : Controller
    {
        public IHistoryManager HistoryManager { get; }

        public HistoryController(IHistoryManager historyManager)
        {
            HistoryManager = historyManager;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Insert([FromBody]GenerateItemsRequest request)
        {
            return Ok(await HistoryManager.GenerateHistoriesAsync(request));
        }
    }
}
