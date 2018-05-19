using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompareDb.Models.MongoDB;

namespace CompareDb.Requests
{
    public class DeleteUserRequest
    {
        public UserType Type { get; set; }
        public int Count { get; set; }
    }
}
