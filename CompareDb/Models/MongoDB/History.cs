using System.Collections.Generic;

namespace CompareDb.Models.MongoDB
{
    public class History
    {
        public string Id { get; set; }
        public string PatientId { get; set; }
        public string DoctorId { get; set; }
        public List<HistoryPoint> HistoryPoints { get; set; }
    }
}
