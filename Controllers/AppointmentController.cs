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
            return View();
        }
    }
}
