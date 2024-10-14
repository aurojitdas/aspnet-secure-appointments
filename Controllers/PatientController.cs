using AppointmentScheduling1.Models;
using DoctorAppointmentSchedulingApp.Models;
using DoctorAppointmentSchedulingApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentSchedulingApp.Controllers
{
    public class PatientController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly ApplicationDbContext _DB;
        public PatientController(IAppointmentService appointmentService, ApplicationDbContext db)
        {
            _appointmentService = appointmentService;
            _DB = db;
        }
        public IActionResult PatientDetails()
        {
           
            List<PatientViewModel> patientList=_appointmentService.GetPatientDetails();
            return View(patientList);
        }

        public IActionResult Update(String id)

        {
            var patient = _DB.Users.Find(id);
           
            if (patient == null)
            {
                return NotFound();
            }
            else
            {
                var patientVM = new PatientViewModel();
                patientVM.Id = patient.Id;
                patientVM.phoneNumber = patient.PhoneNumber;
                patientVM.username = patient.UserName;
                patientVM.Address = patient.Address;
                patientVM.MedicalId = patient.MedicalId;
                patientVM.Name = patient.Name;
                return View(patientVM);
            }     
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(PatientViewModel patientVM)

        {
            if (ModelState.IsValid)
            {
                var patient = _DB.Users.Find(patientVM.Id);
                patient.Id = patientVM.Id;
                patient.PhoneNumber = patientVM.phoneNumber;
                patient.UserName = patientVM.username;
                patient.Address = patientVM.Address;
                patient.MedicalId = patientVM.MedicalId;
                patient.Name = patientVM.Name;
                _DB.Users.Update(patient);
                _DB.SaveChanges();
                return RedirectToAction("PatientDetails");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
