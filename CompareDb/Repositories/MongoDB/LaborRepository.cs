using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using CompareDb.Infrastructure;
using CompareDb.Interfaces.MongoDB;
using CompareDb.Models.MongoDB;
using CompareDb.Responses;

namespace CompareDb.Repositories.MongoDB
{
    public class LaborRepository : BaseRepository<Labor>, ILaborRepository
    {
        public LaborRepository() : base("labors")
        {
        }

        public async Task<InsertResponse> BulkInsertLaborsAsync(List<Labor> labors)
        {
            var sWatch = new Stopwatch();
            sWatch.Start();
            await Collection.InsertManyAsync(labors);
            sWatch.Stop();
            var response = new InsertResponse
            {
                Count = labors.Count,
                ElapsedTime = sWatch.ElapsedMilliseconds.ToString()
            };
            return response;
        }
    }
}
