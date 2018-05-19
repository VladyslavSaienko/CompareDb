using System.Collections.Generic;
using System.Threading.Tasks;
using CompareDb.Requests;
using CompareDb.Responses;

namespace CompareDb.Interfaces.MongoDB
{
    public interface IHospitalManager
    {
        Task<InsertResponse> GenerateHospitalsAsync(GenerateHospitalsRequest request);
        Task<List<string>> GetHospitalsIdAsync();
    }
}