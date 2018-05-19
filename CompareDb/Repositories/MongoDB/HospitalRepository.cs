using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CompareDb.Infrastructure;
using CompareDb.Interfaces.MongoDB;
using CompareDb.Models.MongoDB;
using CompareDb.Responses;
using MongoDB.Driver;

namespace CompareDb.Repositories.MongoDB
{
    public class HospitalRepository : BaseRepository<Hospital>, IHospitalRepository
    {
        public HospitalRepository() : base("hospitals")
        {
        }

        public async Task<InsertResponse> BulkInsertHospitalsAsync(List<Hospital> hospitals)
        {
            var sWatch = new Stopwatch();
            sWatch.Start();
            await Collection.InsertManyAsync(hospitals);
            sWatch.Stop();
            var response = new InsertResponse
            {
                Count = hospitals.Count,
                ElapsedTime = sWatch.ElapsedMilliseconds.ToString()
            };
            return response;
        }

        public async Task<List<string>> GetHospitalsIdAsync()
        {
            var builder = Builders<Hospital>.Filter;
            var filter = builder.Empty;
            var hospitals = await Collection.Find(filter).Limit(1000).ToListAsync();
            return hospitals.Select(hospital => hospital.Id).ToList();
        }
    }
}
