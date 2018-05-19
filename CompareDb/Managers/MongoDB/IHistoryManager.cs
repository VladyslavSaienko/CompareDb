using System.Threading.Tasks;
using CompareDb.Requests;
using CompareDb.Responses;

namespace CompareDb.Managers.MongoDB
{
    public interface IHistoryManager
    {
        Task<InsertResponse> GenerateHistoriesAsync(GenerateItemsRequest request);
    }
}