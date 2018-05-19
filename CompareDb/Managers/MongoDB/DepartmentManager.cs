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
    public class DepartmentManager : IDepartmentManager
    {
        public IDepartmentRepository DepartmentRepository { get; }
        public IHospitalManager HospitalManager { get; }

        public DepartmentManager(IDepartmentRepository departmentRepository, IHospitalManager hospitalManager)
        {
            DepartmentRepository = departmentRepository;
            HospitalManager = hospitalManager;
        }
        public async Task<InsertResponse> GenerateDepartmentsAsync(GenerateDepartmentsAsync request)
        {
            var hospitalIds = await HospitalManager.GetHospitalsIdAsync();
            var departments = new Faker<Department>()
                .RuleFor(u => u.Id, f => ObjectId.GenerateNewId().ToString())
                .RuleFor(bp => bp.Name, f => f.Lorem.Word())
                .RuleFor(bp => bp.HospitalId, f => f.PickRandom(hospitalIds))
                .RuleFor(u => u.Type, f => f.PickRandom<DepartmentType>())
                .RuleFor(u => u.DepartmentInfo, f => f.Lorem.Paragraph())
                .Generate(request.Count).ToList();
            return await DepartmentRepository.BulkInsertDepartmentsAsync(departments);
        }

        public async Task<List<string>> GetDepartmentsIdAsync()
        {
            return await DepartmentRepository.GetDepartmentsIdAsync();
        }
    }
}
