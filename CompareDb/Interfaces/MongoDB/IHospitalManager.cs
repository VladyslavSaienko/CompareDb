using System.Collections.Generic;
using System.Threading.Tasks;
using CompareDb.Requests;
using CompareDb.Responses;

namespace CompareDb.Managers.MongoDB
{
    public interface IHospitalManager
    {
        Task<InsertResponse> GenerateHospitalsAsync(GenerateHospitalsRequest request);
        Task<List<string>> GetHospitalsIdAsync();
    }
}