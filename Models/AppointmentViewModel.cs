namespace DoctorAppointmentSchedulingApp.Models
{
    public class AppointmentViewModel
    {
        public int? Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string StartDate { get; set; }
        public string? EndDate { get; set; }
        public int Duration { get; set; }
        public  string DoctorId { get; set; }
        public  string Patient { get; set; }
        public  string? IsDoctorApproved { get; set; }
        public  string? AdminId { get; set; }
        public  string? DoctorName { get; set; }
        public  string? PatientName { get; set; }
        public  string? AdminName { get; set; }
        public bool? IsForClient {  get; set; }
    }
}
