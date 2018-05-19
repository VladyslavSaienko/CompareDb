using System.Collections.Generic;
using System.Threading.Tasks;
using CompareDb.Requests;
using CompareDb.Responses;

namespace CompareDb.Managers.MongoDB
{
    public interface IDepartmentManager
    {
        Task<InsertResponse> GenerateDepartmentsAsync(GenerateDepartmentsAsync request);
        Task<List<string>> GetDepartmentsIdAsync();
    }
}