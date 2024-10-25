using AppointmentScheduling1.Models;
using DoctorAppointmentSchedulingApp.Models;
using DoctorAppointmentSchedulingApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentSchedulingApp.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly ApplicationDbContext _DB;

        public DoctorController(IAppointmentService appointmentService, ApplicationDbContext db)
        {
            _appointmentService = appointmentService;
            _DB = db;
        }       

        public IActionResult DoctorDetails()
        {

            List<DoctorViewModel> doctorList = _appointmentService.GetDoctorDetails();
            
            // Check if the user is authenticated
            bool isLoggedin = User.Identity.IsAuthenticated;
            if (isLoggedin)
            {
                // If the user is logged in, show the view
                return View(doctorList);            }
            else
            {
                // If the user is not logged in, redirect to the Login page
                return RedirectToAction("Login", "Account");
            }           
        }

        public IActionResult Update(String id)

        {
            var doctor = _DB.Users.Find(id);
            ViewBag.DoctorList = _appointmentService.GetDoctorList();
            ViewBag.PatientList = _appointmentService.GetPatientList();

            if (doctor == null)
            {
                return NotFound();
            }
            else
            {
                var DoctorVM = new DoctorViewModel();
                DoctorVM.Id = doctor.Id;
                DoctorVM.userName = doctor.UserName;
                
                if (doctor.assignMentStatus == null)
                {
                    DoctorVM.assignmentStatus = "False";
                }else if (doctor.assignMentStatus == true)
                {
                    DoctorVM.assignmentStatus = "True";
                }else if (doctor.assignMentStatus == false)
                {
                    DoctorVM.assignmentStatus = "False";
                }
                DoctorVM.assignedTo = doctor.AssignedTo;
                DoctorVM.Name = doctor.Name;
                return View(DoctorVM);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(DoctorViewModel doctorVM)

        {
            if (ModelState.IsValid)
            {
                var doctor = _DB.Users.Find(doctorVM.Id);
                doctor.Id = doctorVM.Id;
                doctor.UserName = doctorVM.userName;
                doctor.Name = doctorVM.Name;
                if (doctorVM.assignmentStatus == null)
                {
                    doctor.assignMentStatus = false;
                }else if (doctorVM.assignmentStatus =="True")
                {
                    doctor.assignMentStatus = true;
                }else if(doctorVM.assignmentStatus == "False")
                {
                    doctor.assignMentStatus = false;
                }               
                doctor.AssignedTo = doctorVM.assignedTo;
                _DB.Users.Update(doctor);
                _DB.SaveChanges();
                return RedirectToAction("DoctorDetails");
            }
            else
            {
                return NotFound();
            }
        }


    }
}
