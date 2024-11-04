using AppointmentScheduling1.Models;
using DoctorAppointmentSchedulingApp.Models;
using DoctorAppointmentSchedulingApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DoctorAppointmentSchedulingApp.Controllers
{
    public class PatientController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAppointmentService _appointmentService;
        private readonly ApplicationDbContext _DB;
        public PatientController(IAppointmentService appointmentService, ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _appointmentService = appointmentService;
            _DB = db;
        }
        public IActionResult PatientDetails()
        {
           
            List<PatientViewModel> patientList=_appointmentService.GetPatientDetails();

            // Check if the user is authenticated
            // If the user is logged in, show the view
            bool isLoggedin = User.Identity.IsAuthenticated;             
            if (isLoggedin)
            {
                String userId = _userManager.GetUserId(User);
                if (User.IsInRole(AppointmentScheduling1.Helper.Roles.Admin)|| User.IsInRole(AppointmentScheduling1.Helper.Roles.Doctor))
                {
                    return View(patientList);
                }
                else if (User.IsInRole(AppointmentScheduling1.Helper.Roles.Patient))
                {
                    //_appointmentService.GetPatientDetailsbyId(userId);
                    PatientViewModel patientDetails = _appointmentService.GetPatientDetailsbyId(userId);
                    List<PatientViewModel> pl = new List<PatientViewModel>();
                    pl.Add(patientDetails);
                    return View(pl);// allowing patients to get their details
                }
                return RedirectToAction("Login", "Account");
            }
            else
            {
                // If the user is not logged in, redirect to the Login page
                return RedirectToAction("Login", "Account");
            }
            
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
                // Return the view with the validation errors
                return View(patientVM);
            }
        }
    }
}
