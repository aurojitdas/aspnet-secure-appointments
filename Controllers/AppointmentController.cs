using DoctorAppointmentSchedulingApp.Helper;
using DoctorAppointmentSchedulingApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentSchedulingApp.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        public IActionResult Index()
        {
           ViewBag.DoctorList = _appointmentService.GetDoctorList();
           ViewBag.PatientList = _appointmentService.GetPatientList();
           ViewBag.Duration = Utility.GetTimeDropDown();

            // Check if the user is authenticated
            bool isLoggedin = User.Identity.IsAuthenticated;
            if (isLoggedin)
            {
                // If the user is logged in, show the Appointment Page
                return View();
            }
            else
            {   
                // If the user is not logged in, redirect to the Login page
                return RedirectToAction("Login", "Account");
            }


            
        }
    }
}
