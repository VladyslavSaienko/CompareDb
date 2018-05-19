namespace CompareDb.Models.MongoDB
{
    public class Hospital
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public HospitalLevel Level { get; set; }
    }
}
