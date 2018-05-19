using System.Threading.Tasks;
using CompareDb.Requests;
using CompareDb.Responses;

namespace CompareDb.Interfaces.MongoDB
{
    public interface IDrugstoreManager
    {
        Task<InsertResponse> GenerateDrugstoresAsync(GenerateItemsRequest request);
    }
}