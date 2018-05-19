using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using CompareDb.Infrastructure;
using CompareDb.Models.EF;
using CompareDb.Models.MongoDB;
using CompareDb.Requests;
using CompareDb.Responses;
using FizzWare.NBuilder;
using MongoDB.Bson;

namespace CompareDb.Managers.EF
{
    public class PatientManager : IPatientManager
    {
        public IRepository<Patient> PatientRepository { get; }

        public PatientManager(IRepository<Patient> patientRepository)
        {
            PatientRepository = patientRepository;
        }

        public async Task<InsertResponse> GenerateUsersAsync(GenerateItemsRequest request)
        {
            var users = new Faker<Patient>()
                .RuleFor(u => u.Id, f => ObjectId.GenerateNewId().ToString())
                .RuleFor(bp => bp.FirstName, f => f.Lorem.Word())
                .RuleFor(bp => bp.LastName, f => f.Lorem.Word())
                .RuleFor(bp => bp.BirthDate, f => f.Date.Between(new DateTime(1930, 1, 1), DateTime.UtcNow))
                .RuleFor(u => u.Gender, f => f.PickRandom<GenderType>())
                .RuleFor(u => u.Type, f => UserType.Patient)
                .RuleFor(bp => bp.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(bp => bp.Email, f => f.Internet.Email())
                .RuleFor(bp => bp.City, f => f.Address.City())
                .RuleFor(bp => bp.Street, f => f.Address.StreetName())
                .RuleFor(bp => bp.Country, f => f.Address.Country())
                .RuleFor(u => u.Email,
                    (f, u) => f.Internet.Email(u.FirstName + f.Random.Number(1, 1000),
                        u.LastName + f.Random.Number(1, 1000)))
                .Generate(request.Count).ToList();

            return await PatientRepository.Create(users);
        }
    }
}
