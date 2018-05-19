using System.Collections.Generic;
using System.Threading.Tasks;
using CompareDb.Models.Filters;
using CompareDb.Models.MongoDB;
using CompareDb.Requests;
using CompareDb.Responses;

namespace CompareDb.Interfaces.MongoDB
{
    public interface IUserRepository
    {
        Task<DeleteResponse> BulkDeleteContractAsync(DeleteUserRequest request);
        Task<InsertResponse> BulkInsertUsersAsync(List<UserModel> contracts);
        Task<SearchResponse> GetUsersByFilterAsync(UserFilter userFilter);
        Task<List<string>> GetUsersIdAsync(UsersIdRequest request);
    }
}