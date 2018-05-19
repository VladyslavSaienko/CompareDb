using System.Threading.Tasks;
using CompareDb.Requests;
using CompareDb.Responses;

namespace CompareDb.Managers.EF
{
    public interface IPatientManager
    {
        Task<InsertResponse> GenerateUsersAsync(GenerateItemsRequest request);
    }
}