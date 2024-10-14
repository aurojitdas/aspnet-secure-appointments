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

        public async Task<int> AddUpdate(AppointmentViewModel model)
        {
            var startDate = DateTime.Parse(model.StartDate);
            var endDate = DateTime.Parse(model.StartDate).AddMinutes(Convert.ToDouble(model.Duration));

            if(model!=null && model.Id > 0)
            {
                //update Logic
                var appointment = _DB.Appointments.FirstOrDefault(x => x.Id == model.Id);
                appointment.Title = model.Title;
                appointment.Description = model.Description;
                appointment.StartDate = startDate;
                appointment.EndDate = endDate;
                appointment.Duration = model.Duration;
                appointment.DoctorId = model.DoctorId;
                appointment.Patient = model.Patient;
                appointment.IsDoctorApproved = false;
                appointment.AdminId = model.AdminId;
                await _DB.SaveChangesAsync();

                return 1;
            }
            else
            {
                //Create Logic
                Appointment appointment = new Appointment()
                {
                    Title = model.Title,
                    Description = model.Description,
                    StartDate = startDate,
                    EndDate = endDate,
                    Duration = model.Duration,
                    DoctorId = model.DoctorId,
                    Patient = model.Patient,
                    IsDoctorApproved = false,
                    AdminId = model.AdminId
                };
                _DB.Appointments.Add(appointment);
                await _DB.SaveChangesAsync();
                return 2;

            }
        }
        //Getting DoctorEvents
        public List<AppointmentViewModel> DoctorsEventById(string doctorId)
        {
            doctorId = doctorId.Trim();
            var appointmentQuery = _DB.Appointments.Where(x => x.DoctorId == doctorId);
            var appointmentList = appointmentQuery.ToList();
            List<AppointmentViewModel> listOfAppointment = appointmentList.Select(c => new AppointmentViewModel()
            {
                Id = c.Id,
                Description = c.Description,
                StartDate = c.StartDate.ToString("yyyy-MM-dd HH:mm:ss"),
                EndDate = c.EndDate.ToString("yyyy-MM-dd HH:mm:ss"),
                Title = c.Title,
                Duration = c.Duration,
                IsDoctorApproved = c.IsDoctorApproved.ToString(),
                Patient = c.Patient,
                DoctorId = c.DoctorId,
            }).ToList();

            return listOfAppointment;
        }

        public AppointmentViewModel GetById(int id)
        {            
            var appointmentQuery = _DB.Appointments.Where(x => x.Id == id);
            var appointmentList = appointmentQuery.ToList();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            AppointmentViewModel listOfAppointment = appointmentList.Select(c => new AppointmentViewModel()
            {
                Id = c.Id,
                Description = c.Description,
                StartDate = c.StartDate.ToString("yyyy-MM-dd HH:mm:ss"),
                EndDate = c.EndDate.ToString("yyyy-MM-dd HH:mm:ss"),
                Title = c.Title,
                Duration = c.Duration,
                IsDoctorApproved = c.IsDoctorApproved.ToString(),
                Patient = c.Patient,
                DoctorId = c.DoctorId,
                PatientName = _DB.Users.Where(x=>x.Id==c.Patient).Select(x=>x.Name).FirstOrDefault(),
                DoctorName = _DB.Users.Where(x => x.Id == c.DoctorId).Select(x => x.Name).FirstOrDefault(),
            }).SingleOrDefault();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            return listOfAppointment;
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
        //Returns all the list of patients with their details
        public List<PatientViewModel> GetPatientDetails()
        {
            var patients = (from user in _DB.Users
                            join userRoles in _DB.UserRoles on user.Id equals userRoles.UserId
                            join roles in _DB.Roles.Where(x => x.Name == Roles.Patient) on userRoles.RoleId equals roles.Id
                            select new PatientViewModel  //Using Projections to get the   list of doctors
                            {
                                Id = user.Id,
                                Name = user.Name,
                                Address= user.Address,
                                MedicalId= user.MedicalId,
                                username = user.UserName,
                                phoneNumber = user.PhoneNumber

                                
                            }
                          ).ToList();
            return patients;
        }

        //Getting PatientEvents
        public List<AppointmentViewModel> PatientsEventById(string patientId)
        {
            patientId = patientId.Trim();
            var appointmentQuery = _DB.Appointments.Where(x => x.Patient == patientId);
            var appointmentList = appointmentQuery.ToList();
            List<AppointmentViewModel> listOfAppointment = appointmentList.Select(c => new AppointmentViewModel()
            {
                Id = c.Id,
                Description = c.Description,
                StartDate = c.StartDate.ToString("yyyy-MM-dd HH:mm:ss"),
                EndDate = c.EndDate.ToString("yyyy-MM-dd HH:mm:ss"),
                Title = c.Title,
                Duration = c.Duration,
                IsDoctorApproved = c.IsDoctorApproved.ToString(),
                Patient = c.Patient,
                DoctorId = c.DoctorId,
            }).ToList();

            return listOfAppointment;
        }
       
    }
}
