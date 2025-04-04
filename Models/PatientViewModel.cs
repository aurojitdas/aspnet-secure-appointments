﻿using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentSchedulingApp.Models
{
    public class PatientViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set;}

        public string? Address { get; set; }

        public string? MedicalId { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string username {  get; set; }

        public string? phoneNumber { get; set; }
    }
}
