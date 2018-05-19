using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CompareDb.Infrastructure;
using CompareDb.Interfaces.MongoDB;
using CompareDb.Models.MongoDB;
using CompareDb.Responses;

namespace CompareDb.Repositories.MongoDB
{
    public class DrugstoreRepository : BaseRepository<Drugstore>, IDrugstoreRepository
    {
        public DrugstoreRepository() : base("drugstores")
        {
        }

        public async Task<InsertResponse> BulkInsertDrugstoresAsync(List<Drugstore> drugstores)
        {
            var sWatch = new Stopwatch();
            sWatch.Start();
            await Collection.InsertManyAsync(drugstores);
            sWatch.Stop();
            var response = new InsertResponse
            {
                Count = drugstores.Count,
                ElapsedTime = sWatch.ElapsedMilliseconds.ToString()
            };
            return response;
        }
    }
}
