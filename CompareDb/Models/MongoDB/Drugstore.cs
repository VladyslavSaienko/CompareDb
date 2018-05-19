namespace CompareDb.Models.MongoDB
{
    public class Drugstore
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public string HospitalId { get; set; }
    }
}
