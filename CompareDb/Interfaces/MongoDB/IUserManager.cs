using System.Collections.Generic;
using System.Threading.Tasks;
using CompareDb.Models.Filters;
using CompareDb.Requests;
using CompareDb.Responses;

namespace CompareDb.Interfaces.MongoDB
{
    public interface IUserManager
    {
        Task<InsertResponse> GenerateUsersAsync(GenerateUserRequest request);
        Task<SearchResponse> GetUsersByFilterAsync(UserFilter userFilter);
        Task<DeleteResponse> BulkDeleteContractAsync(DeleteUserRequest request);
        Task<List<string>> GetUsersIdAsync(UsersIdRequest request);
    }
}