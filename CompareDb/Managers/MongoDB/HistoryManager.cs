using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompareDb.Interfaces.MongoDB;
using CompareDb.Models.Filters;
using CompareDb.Models.MongoDB;
using CompareDb.Repositories.MongoDB;
using CompareDb.Requests;
using CompareDb.Responses;
using Faker;
using FizzWare.NBuilder;
using MongoDB.Bson;

namespace CompareDb.Managers.MongoDB
{
    public class HistoryManager : IHistoryManager
    {
        public IHistoryRepository HistoryRepository { get; }
        public IUserManager UserManager { get; }

        public HistoryManager(IHistoryRepository historyRepository, IUserManager userManager)
        {
            HistoryRepository = historyRepository;
            UserManager = userManager;
        }

        public async Task<InsertResponse> GenerateHistoriesAsync(GenerateItemsRequest request)
        {
            var patientIds = await UserManager.GetUsersIdAsync(new UsersIdRequest
            {
                Amount = request.Count,
                UserType = UserType.Patient
            });
            var doctorIds = await UserManager.GetUsersIdAsync(new UsersIdRequest
            {
                Amount = request.Count,
                UserType = UserType.Doctor
            });

            var historyPoints = Builder<HistoryPoint>.CreateNew()
                .With(e => e.CreationDate = Date.Between(new DateTime(1930, 1, 1), DateTime.UtcNow))
                .With(e => e.Report = Faker.Lorem.Paragraph());

            var histories = new Bogus.Faker<History>()
                .RuleFor(u => u.Id, f => ObjectId.GenerateNewId().ToString())
                .RuleFor(bp => bp.DoctorId, f => f.PickRandom(doctorIds))
                .RuleFor(bp => bp.PatientId, f => f.PickRandom(patientIds))
                .RuleFor(u => u.HistoryPoints, f => f.Make(10, () => historyPoints.Build()))
                .Generate(request.Count).ToList();
            return await HistoryRepository.BulkInsertHistoriesAsync(histories);
        }
    }
}
