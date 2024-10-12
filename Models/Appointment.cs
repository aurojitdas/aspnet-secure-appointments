namespace DoctorAppointmentSchedulingApp.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public string DoctorId { get; set; }
        public string Patient {  get; set; }

        public string IsDoctorApproved { get; set; }
        public string AdminId { get; set; }
         


    }
}
