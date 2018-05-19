using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using CompareDb.Infrastructure;
using CompareDb.Interfaces.MongoDB;
using CompareDb.Models.MongoDB;
using CompareDb.Responses;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace CompareDb.Repositories.MongoDB
{
    public class ContractRepository : BaseRepository<Contract>, IContractRepository
    {
        public ContractRepository() : base("contracts")
        {
        }

        public async Task<InsertResponse> BulkInsertContractAsync(List<Contract> contracts)
        {
            var sWatch = new Stopwatch();
            sWatch.Start();
            await Collection.InsertManyAsync(contracts);
            sWatch.Stop();
            var response = new InsertResponse
            {
                Count = contracts.Count,
                ElapsedTime = sWatch.ElapsedMilliseconds.ToString()
            };
            return response;
        }
        public async Task BulkUpdateContractAsync(string patientId)
        {
            var builder = Builders<Contract>.Filter;
            var filter = builder.Eq(x => x.PatientId, patientId);

            var update = Builders<Contract>.Update.Set(x => x.PatientId, patientId);
            await Collection.UpdateManyAsync(filter, update);
        }
        public async Task BulkDeleteContractAsync(List<Contract> contracts)
        {
            var builder = Builders<Contract>.Filter;
            var filter = builder.Empty;
            await Collection.DeleteManyAsync(filter);
        }
    }
}
