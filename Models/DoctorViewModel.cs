namespace DoctorAppointmentSchedulingApp.Models
{
    public class DoctorViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string assignedTo { get; set; }
        public string? assignmentStatus { get; set; }

        public string userName { get; set; }
    }
}
