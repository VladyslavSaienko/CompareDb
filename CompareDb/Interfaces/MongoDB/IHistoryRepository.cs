using System.Collections.Generic;
using System.Threading.Tasks;
using CompareDb.Models.MongoDB;
using CompareDb.Responses;

namespace CompareDb.Interfaces.MongoDB
{
    public interface IHistoryRepository
    {
        Task<InsertResponse> BulkInsertHistoriesAsync(List<History> histories);
    }
}