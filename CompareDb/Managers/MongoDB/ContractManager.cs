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
using MongoDB.Bson;

namespace CompareDb.Managers.MongoDB
{
    public class ContractManager : IContractManager
    {
        public IContractRepository ContractRepository { get; }
        public IUserManager UserManager { get; }

        public ContractManager(IContractRepository contractRepository, IUserManager userManager)
        {
            ContractRepository = contractRepository;
            UserManager = userManager;
        }

        public async Task<InsertResponse> GenerateContractsAsync(GenerateItemsRequest request)
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
            var familyMemberIds = await UserManager.GetUsersIdAsync(new UsersIdRequest
            {
                Amount = request.Count,
                UserType = UserType.FamilyMember
            });

            var contracts = new Faker<Contract>()
                .RuleFor(u => u.Id, f => ObjectId.GenerateNewId().ToString())
                .RuleFor(bp => bp.PatientId, f => f.PickRandom(patientIds))
                .RuleFor(bp => bp.DoctorId, f => f.PickRandom(doctorIds))
                .RuleFor(bp => bp.FamilyMemberId, f => f.PickRandom(familyMemberIds))
                .Generate(request.Count).ToList();
            return await ContractRepository.BulkInsertContractAsync(contracts);
        }
    }
}
