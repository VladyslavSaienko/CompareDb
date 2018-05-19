using System.Threading.Tasks;
using CompareDb.Requests;
using CompareDb.Responses;

namespace CompareDb.Managers.MongoDB
{
    public interface ILaborManager
    {
        Task<InsertResponse> GenerateDepartmentsAsync(GenerateLaborsRequest request);
    }
}