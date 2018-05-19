using System.Collections.Generic;
using System.Threading.Tasks;
using CompareDb.Models.MongoDB;
using CompareDb.Responses;

namespace CompareDb.Interfaces.MongoDB
{
    public interface IDrugstoreRepository
    {
        Task<InsertResponse> BulkInsertDrugstoresAsync(List<Drugstore> drugstores);
    }
}