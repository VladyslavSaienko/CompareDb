using CompareDb.Models.MongoDB;

namespace CompareDb.Models.EF
{
    public class Hospital
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public HospitalLevel Level { get; set; }
    }
}
