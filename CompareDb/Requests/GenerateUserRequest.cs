using CompareDb.Models.MongoDB;

namespace CompareDb.Requests
{
    public class GenerateUserRequest
    {
        public int Count { get; set; }
        public UserType UserType { get; set; }
    }
}
