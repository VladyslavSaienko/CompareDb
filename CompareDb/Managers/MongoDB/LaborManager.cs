using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using CompareDb.Interfaces.MongoDB;
using CompareDb.Models.MongoDB;
using CompareDb.Repositories.MongoDB;
using CompareDb.Requests;
using CompareDb.Responses;
using FizzWare.NBuilder;
using MongoDB.Bson;

namespace CompareDb.Managers.MongoDB
{
    public class LaborManager : ILaborManager
    {
        public ILaborRepository LaborRepository { get; }
        public IHospitalManager HospitalManager { get; }

        public LaborManager(ILaborRepository laborRepository, IHospitalManager hospitalManager)
        {
            LaborRepository = laborRepository;
            HospitalManager = hospitalManager;
        }

        public async Task<InsertResponse> GenerateDepartmentsAsync(GenerateLaborsRequest request)
        {
            var address = Builder<Address>.CreateNew()
                .With(e => e.City = Faker.Address.USCity())
                .With(e => e.Street = Faker.Address.StreetName())
                .With(e => e.Country = Faker.Address.Country());

            var hospitalIds = await HospitalManager.GetHospitalsIdAsync();
            var labors = new Faker<Labor>()
                .RuleFor(u => u.Id, f => ObjectId.GenerateNewId().ToString())
                .RuleFor(bp => bp.Name, f => f.Lorem.Word())
                .RuleFor(bp => bp.HospitalId, f => f.PickRandom(hospitalIds))
                .RuleFor(u => u.Type, f => f.PickRandom<LaborType>())
                .RuleFor(u => u.Address, f => address.Build())
                .Generate(request.Count).ToList();
            return await LaborRepository.BulkInsertLaborsAsync(labors);
        }
    }
}
