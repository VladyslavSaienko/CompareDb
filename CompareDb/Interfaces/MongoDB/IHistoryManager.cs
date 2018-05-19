using System.Threading.Tasks;
using CompareDb.Requests;
using CompareDb.Responses;

namespace CompareDb.Interfaces.MongoDB
{
    public interface IHistoryManager
    {
        Task<InsertResponse> GenerateHistoriesAsync(GenerateItemsRequest request);
    }
}