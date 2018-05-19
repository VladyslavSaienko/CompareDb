using System.Threading.Tasks;
using CompareDb.Requests;
using CompareDb.Responses;

namespace CompareDb.Interfaces.MongoDB
{
    public interface ILaborManager
    {
        Task<InsertResponse> GenerateDepartmentsAsync(GenerateLaborsRequest request);
    }
}