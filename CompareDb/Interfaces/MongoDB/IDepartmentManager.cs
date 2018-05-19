using System.Collections.Generic;
using System.Threading.Tasks;
using CompareDb.Requests;
using CompareDb.Responses;

namespace CompareDb.Interfaces.MongoDB
{
    public interface IDepartmentManager
    {
        Task<InsertResponse> GenerateDepartmentsAsync(GenerateDepartmentsAsync request);
        Task<List<string>> GetDepartmentsIdAsync();
    }
}