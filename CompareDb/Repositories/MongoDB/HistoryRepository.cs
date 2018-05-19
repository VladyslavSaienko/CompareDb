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
    public class HistoryRepository : BaseRepository<History>, IHistoryRepository
    {
        public HistoryRepository() : base("histories")
        {
        }

        public async Task<InsertResponse> BulkInsertHistoriesAsync(List<History> histories)
        {
            var sWatch = new Stopwatch();
            sWatch.Start();
            await Collection.InsertManyAsync(histories);
            sWatch.Stop();
            var response = new InsertResponse
            {
                Count = histories.Count,
                ElapsedTime = sWatch.ElapsedMilliseconds.ToString()
            };
            return response;
        }
    }
}
