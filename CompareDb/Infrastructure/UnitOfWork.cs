using System;
using CompareDb.Models.EF;

namespace CompareDb.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Patient> Patients { get; }
        IRepository<Hospital> EFHospitals { get; }
        void Save();
    }
}
