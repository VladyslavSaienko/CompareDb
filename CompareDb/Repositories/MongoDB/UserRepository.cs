using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CompareDb.Infrastructure;
using CompareDb.Interfaces.MongoDB;
using CompareDb.Models.Filters;
using CompareDb.Models.MongoDB;
using CompareDb.Requests;
using CompareDb.Responses;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Operations;

namespace CompareDb.Repositories.MongoDB
{
    public class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
        public UserRepository() : base("users")
        {
        }

        public async Task<InsertResponse> BulkInsertUsersAsync(List<UserModel> users)
        {
            var sWatch = new Stopwatch();
            sWatch.Start();
            await Collection.InsertManyAsync(users);
            sWatch.Stop();
            var response = new InsertResponse
            {
                Count = users.Count,
                ElapsedTime = sWatch.ElapsedMilliseconds.ToString()
            };
            return response;
        }

        //public async Task BulkUpdateContractAsync(string patientId)
        //{
        //    var builder = global::MongoDB.Driver.Builders<UserModel>.Filter;
        //    var filter = builder.Eq(x => x.PatientId, patientId);

        //    var update = global::MongoDB.Driver.Builders<UserModel>.Update.Set(x => x.PatientId, patientId);
        //    await Collection.UpdateManyAsync(filter, update);
        //}
        public async Task<DeleteResponse> BulkDeleteContractAsync(DeleteUserRequest request)
        {
            var builder = Builders<UserModel>.Filter;
            var filter = builder.Empty;
            filter = builder.And(filter, builder.Where(c => c.Type == request.Type));
            var sWatch = new Stopwatch();
            sWatch.Start();
            await Collection.DeleteManyAsync(filter);
            var response = new DeleteResponse
            {
                Count = request.Count,
                ElapsedTime = sWatch.ElapsedMilliseconds.ToString()
            };
            return response;

        }

        public async Task<SearchResponse> GetUsersByFilterAsync(UserFilter userFilter)
        {
            var builder = Builders<UserModel>.Filter;
            var filter = builder.Empty;

            if (userFilter.UserType != null)
                filter = builder.And(filter, builder.Where(c => c.Type == userFilter.UserType));
            if (!string.IsNullOrEmpty(userFilter.Country))
                filter = builder.And(filter, builder.Where(c => c.Address.Country == userFilter.Country));

            var sWatch = new Stopwatch();
            sWatch.Start();
            var users = await Collection.Find(filter).ToListAsync();
            sWatch.Stop();
            var response = new SearchResponse
            {
                Count = users.Count,
                ElapsedTime = sWatch.ElapsedMilliseconds.ToString()
            };
            return response;
        }

        public async Task<List<string>> GetUsersIdAsync(UsersIdRequest request)
        {
            var builder = Builders<UserModel>.Filter;
            var filter = builder.Empty;
            filter = builder.And(filter, builder.Where(c => c.Type == request.UserType));
            var users = await Collection.Find(filter).Limit(request.Amount).ToListAsync();
            return users.Select(user => user.Id).ToList();
        }
    }
}
