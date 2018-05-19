using System.Collections.Generic;
using System.Threading.Tasks;
using CompareDb.Models.MongoDB;
using CompareDb.Responses;

namespace CompareDb.Interfaces.MongoDB
{
    public interface IContractRepository
    {
        Task BulkDeleteContractAsync(List<Contract> contracts);
        Task<InsertResponse> BulkInsertContractAsync(List<Contract> contracts);
        Task BulkUpdateContractAsync(string patientId);
    }
}