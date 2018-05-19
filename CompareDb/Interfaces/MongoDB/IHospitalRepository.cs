using System.Collections.Generic;
using System.Threading.Tasks;
using CompareDb.Models.MongoDB;
using CompareDb.Responses;

namespace CompareDb.Repositories.MongoDB
{
    public interface IHospitalRepository
    {
        Task<InsertResponse> BulkInsertHospitalsAsync(List<Hospital> hospitals);
        Task<List<string>> GetHospitalsIdAsync();
    }
}