using System.Threading.Tasks;
using CompareDb.Requests;
using CompareDb.Responses;

namespace CompareDb.Managers.MongoDB
{
    public interface IContractManager
    {
        Task<InsertResponse> GenerateContractsAsync(GenerateItemsRequest request);
    }
}