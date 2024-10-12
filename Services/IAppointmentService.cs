using DoctorAppointmentSchedulingApp.Models;

namespace DoctorAppointmentSchedulingApp.Services
{
    public interface IAppointmentService
    {
        public List<DoctorViewModel>   GetDoctorList();

        public List<PatientViewModel> GetPatientList();
    }
}
