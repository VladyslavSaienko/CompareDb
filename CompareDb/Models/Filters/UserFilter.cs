using CompareDb.Models.MongoDB;

namespace CompareDb.Models.Filters
{
    public class UserFilter
    {
        public UserType? UserType { get; set; }
        public string Country { get; set; }
    }
}
