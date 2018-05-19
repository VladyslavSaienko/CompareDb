namespace CompareDb.Models.MongoDB
{
    public class Labor
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public LaborType Type { get; set; }
        public string HospitalId { get; set; }
        public Address Address { get; set; }
    }
}
