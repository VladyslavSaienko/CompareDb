using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using CompareDb.Infrastructure;
using CompareDb.Interfaces.EF;
using CompareDb.Models.MongoDB;
using CompareDb.Requests;
using CompareDb.Responses;
using FizzWare.NBuilder;
using MongoDB.Bson;
using Hospital = CompareDb.Models.EF.Hospital;

namespace CompareDb.Managers.EF
{
    public class EFHospitalManager : IEFHospitalManager
    {
        public IRepository<Hospital> HospitalRepository { get; }

        public EFHospitalManager(IRepository<Hospital> hospitalRepository)
        {
            HospitalRepository = hospitalRepository;
        }

        public async Task<InsertResponse> GenerateHospitalsAsync(GenerateItemsRequest request)
        {
            var hospitals = new Faker<Hospital>()
                .RuleFor(u => u.Id, f => ObjectId.GenerateNewId().ToString())
                .RuleFor(bp => bp.Name, f => f.Lorem.Word())
                .RuleFor(u => u.Level, f => f.PickRandom<HospitalLevel>())
                .RuleFor(bp => bp.City, f => f.Address.City())
                .RuleFor(bp => bp.Street, f => f.Address.StreetName())
                .RuleFor(bp => bp.Country, f => f.Address.Country())
                .Generate(request.Count).ToList();
            return await HospitalRepository.Create(hospitals);
        }

    }
}
