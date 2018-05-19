using CompareDb.Models.MongoDB;

namespace CompareDb.Models.Filters
{
    public class UsersIdRequest
    {
        public int Amount { get; set; }
        public UserType UserType { get; set; }
    }
}
