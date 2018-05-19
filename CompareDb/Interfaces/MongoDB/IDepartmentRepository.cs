using System.Collections.Generic;
using System.Threading.Tasks;
using CompareDb.Models.MongoDB;
using CompareDb.Responses;

namespace CompareDb.Repositories.MongoDB
{
    public interface IDepartmentRepository
    {
        Task<InsertResponse> BulkInsertDepartmentsAsync(List<Department> departments);
        Task<List<string>> GetDepartmentsIdAsync();
    }
}