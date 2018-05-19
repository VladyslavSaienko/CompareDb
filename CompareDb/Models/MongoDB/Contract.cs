namespace CompareDb.Models.MongoDB
{
    public class Contract
    {
        public string Id { get; set; }
        public string PatientId { get; set; }
        public string DoctorId { get; set; }
        public string FamilyMemberId { get; set; }
    }
}
