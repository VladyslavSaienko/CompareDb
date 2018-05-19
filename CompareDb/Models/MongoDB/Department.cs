namespace CompareDb.Models.MongoDB
{
    public class Department
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DepartmentType Type { get; set; }
        public string HospitalId { get; set; }
        public string DepartmentInfo { get; set; }
    }
}
