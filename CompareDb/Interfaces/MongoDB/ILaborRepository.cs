using System.Collections.Generic;
using System.Threading.Tasks;
using CompareDb.Models.MongoDB;
using CompareDb.Responses;

namespace CompareDb.Repositories.MongoDB
{
    public interface ILaborRepository
    {
        Task<InsertResponse> BulkInsertLaborsAsync(List<Labor> labors);
    }
}