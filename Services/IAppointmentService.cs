using DoctorAppointmentSchedulingApp.Models;

namespace DoctorAppointmentSchedulingApp.Services
{
    public interface IAppointmentService
    {
        public List<DoctorViewModel>   GetDoctorList();
        public List<PatientViewModel> GetPatientList();
        public Task<int> AddUpdate(AppointmentViewModel model);

        public List<AppointmentViewModel> DoctorsEventById(string doctorId);
        public List<AppointmentViewModel> PatientsEventById(string patientId);

        public AppointmentViewModel GetById(int id);
        public List<PatientViewModel> GetPatientDetails();

        public List<DoctorViewModel> GetDoctorDetails();

        public PatientViewModel GetPatientDetailsbyId(String id);
    }
}
