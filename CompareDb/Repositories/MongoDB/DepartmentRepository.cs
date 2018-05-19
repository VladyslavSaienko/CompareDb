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
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository() : base("departments")
        {
        }

        public async Task<InsertResponse> BulkInsertDepartmentsAsync(List<Department> departments)
        {
            var sWatch = new Stopwatch();
            sWatch.Start();
            await Collection.InsertManyAsync(departments);
            sWatch.Stop();
            var response = new InsertResponse
            {
                Count = departments.Count,
                ElapsedTime = sWatch.ElapsedMilliseconds.ToString()
            };
            return response;
        }

        public async Task<List<string>> GetDepartmentsIdAsync()
        {
            var builder = Builders<Department>.Filter;
            var filter = builder.Empty;
            var departments = await Collection.Find(filter).Limit(1000).ToListAsync();
            return departments.Select(hospital => hospital.Id).ToList();
        }
    }
}
