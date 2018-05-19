using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using CompareDb.Interfaces.MongoDB;
using CompareDb.Models.Filters;
using CompareDb.Models.MongoDB;
using CompareDb.Repositories.MongoDB;
using CompareDb.Requests;
using CompareDb.Responses;
using FizzWare.NBuilder;
using MongoDB.Bson;

namespace CompareDb.Managers.MongoDB
{
    public class UserManager : IUserManager
    {
        public IUserRepository UserRepository { get; }

        public UserManager(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public async Task<InsertResponse> GenerateUsersAsync(GenerateUserRequest request)
        {
            var address = Builder<Address>.CreateNew()
                .With(e => e.City = Faker.Address.USCity())
                .With(e => e.Street = Faker.Address.StreetName())
                .With(e => e.Country = Faker.Address.Country());

            var users = new Faker<UserModel>()
                .RuleFor(u => u.Id, f => ObjectId.GenerateNewId().ToString())
                .RuleFor(bp => bp.FirstName, f => f.Lorem.Word())
                .RuleFor(bp => bp.LastName, f => f.Lorem.Word())
                .RuleFor(bp => bp.BirthDate, f => f.Date.Between(new DateTime(1930, 1, 1), DateTime.UtcNow))
                .RuleFor(u => u.Gender, f => f.PickRandom<GenderType>())
                .RuleFor(u => u.Type, f => f.PickRandom<UserType>())
                .RuleFor(bp => bp.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(bp => bp.Email, f => f.Internet.Email())
                .RuleFor(u => u.Address, f => address.Build())
                .RuleFor(u => u.Email,
                    (f, u) => f.Internet.Email(u.FirstName + f.Random.Number(1, 1000),
                        u.LastName + f.Random.Number(1, 1000)))
                .Generate(request.Count).ToList();

            return await UserRepository.BulkInsertUsersAsync(users);
        }

        public async Task<SearchResponse> GetUsersByFilterAsync(UserFilter userFilter)
        {
            return await UserRepository.GetUsersByFilterAsync(userFilter);
        }

        public async Task<DeleteResponse> BulkDeleteContractAsync(DeleteUserRequest request)
        {
            return await UserRepository.BulkDeleteContractAsync(request);
        }

        public async Task<List<string>> GetUsersIdAsync(UsersIdRequest request)
        {
            return await UserRepository.GetUsersIdAsync(request);
        }
    }
}
