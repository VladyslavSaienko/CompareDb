using System.Threading.Tasks;
using CompareDb.Requests;
using CompareDb.Responses;

namespace CompareDb.Interfaces.EF
{
    public interface IEFHospitalManager
    {
        Task<InsertResponse> GenerateHospitalsAsync(GenerateItemsRequest request);
    }
}