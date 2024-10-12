namespace DoctorAppointmentSchedulingApp.Models
{
    public class CommonResponse<T> 
    {
        public int Status { get; set; }
        public string Message { get; set; }

        public T dataenum { get; set; }
    }
}
