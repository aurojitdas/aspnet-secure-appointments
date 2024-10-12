using AppointmentScheduling1.Helper;
using AppointmentScheduling1.Models;
using DoctorAppointmentSchedulingApp.Models;

namespace DoctorAppointmentSchedulingApp.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _DB;

        //Getting ApplicationDB Context
        public AppointmentService(ApplicationDbContext db) { 
            _DB = db;
        }

        //Getting the list of doctors from the UsersTable
        public List<DoctorViewModel> GetDoctorList()
        {
            var doctors = (from user in _DB.Users  
                           join userRoles in _DB.UserRoles on user.Id equals userRoles.UserId
                           join roles in _DB.Roles.Where(x=>x.Name==Roles.Doctor) on userRoles.RoleId equals roles.Id
                           select new DoctorViewModel   //Using Projections to get the   list of doctors
                           {
                               Id = user.Id,
                               Name = user.Name
                           }
                           ).ToList();
            return doctors;
        }

        public List<PatientViewModel> GetPatientList()
        {
            var patients = (from user in _DB.Users
                           join userRoles in _DB.UserRoles on user.Id equals userRoles.UserId
                           join roles in _DB.Roles.Where(x => x.Name == Roles.Patient) on userRoles.RoleId equals roles.Id
                           select new PatientViewModel  //Using Projections to get the   list of doctors
                           {
                               Id = user.Id,
                               Name = user.Name
                           }
                          ).ToList();
            return patients;
        }
    }
}
