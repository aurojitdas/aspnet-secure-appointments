﻿namespace DoctorAppointmentSchedulingApp.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public  string Title { get; set; }
        public  string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public  string DoctorId { get; set; }
        public  string Patient {  get; set; }
        public bool IsDoctorApproved { get; set; }
        public  string AdminId { get; set; }
         


    }
}
