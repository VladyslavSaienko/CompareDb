using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using CompareDb.Infrastructure;
using CompareDb.Models.EF;
using CompareDb.Responses;

namespace CompareDb.Repositories.EF
{
    public class EFPatientRepository : IRepository<Patient>
    {
        private ApplicationContext db;

        public EFPatientRepository(ApplicationContext appContext)
        {
            db = appContext;
        }

        public async Task<InsertResponse> Create(List<Patient> items)
        {
            var sWatch = new Stopwatch();
            sWatch.Start();
            
            db.BulkInsert(items);
            sWatch.Stop();
            var response = new InsertResponse
            {
                Count = items.Count,
                ElapsedTime = sWatch.ElapsedMilliseconds.ToString()
            };
            return response;
        }
    }
}
