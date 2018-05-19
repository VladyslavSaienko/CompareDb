using System.Threading.Tasks;
using CompareDb.Interfaces.MongoDB;
using CompareDb.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CompareDb.Controllers.MongoDB
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
