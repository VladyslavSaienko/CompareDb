using System.Threading.Tasks;
using CompareDb.Requests;
using CompareDb.Responses;

namespace CompareDb.Managers.MongoDB
{
    public interface IDrugstoreManager
    {
        Task<InsertResponse> GenerateDrugstoresAsync(GenerateItemsRequest request);
    }
}