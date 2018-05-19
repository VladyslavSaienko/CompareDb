using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using CompareDb.Models.MongoDB;
using CompareDb.Repositories.MongoDB;
using CompareDb.Requests;
using CompareDb.Responses;
using FizzWare.NBuilder;
using MongoDB.Bson;

namespace CompareDb.Managers.MongoDB
{
    public class HospitalManager : IHospitalManager
    {
        public IHospitalRepository HospitalRepository { get; }

        public HospitalManager(IHospitalRepository hospitalRepository)
        {
            HospitalRepository = hospitalRepository;
        }

        public async Task<InsertResponse> GenerateHospitalsAsync(GenerateHospitalsRequest request)
        {
            var address = Builder<Address>.CreateNew()
                .With(e => e.City = Faker.Address.USCity())
                .With(e => e.Street = Faker.Address.StreetName())
                .With(e => e.Country = Faker.Address.Country());

            var hospitals = new Faker<Hospital>()
                .RuleFor(u => u.Id, f => ObjectId.GenerateNewId().ToString())
                .RuleFor(bp => bp.Name, f => f.Lorem.Word())
                .RuleFor(u => u.Level, f => f.PickRandom<HospitalLevel>())
                .RuleFor(u => u.Address, f => address.Build())
                .Generate(request.Count).ToList();
            return await HospitalRepository.BulkInsertHospitalsAsync(hospitals);
        }

        public async Task<List<string>> GetHospitalsIdAsync()
        {
            return await HospitalRepository.GetHospitalsIdAsync();
        }
    }
}
