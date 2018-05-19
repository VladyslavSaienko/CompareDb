using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompareDb.Responses;

namespace CompareDb.Infrastructure
{
    public interface IRepository<T> where T: class
    {
        Task<InsertResponse> Create(List<T> items);
    }
}
