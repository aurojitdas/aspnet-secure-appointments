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
            return View();
        }
    }
}
