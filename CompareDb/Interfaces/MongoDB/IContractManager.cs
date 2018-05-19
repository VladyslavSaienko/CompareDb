using System.Threading.Tasks;
using CompareDb.Requests;
using CompareDb.Responses;

namespace CompareDb.Interfaces.MongoDB
{
    public interface IContractManager
    {
        Task<InsertResponse> GenerateContractsAsync(GenerateItemsRequest request);
    }
}