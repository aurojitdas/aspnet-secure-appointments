using AppointmentScheduling1.Helper;
using DoctorAppointmentSchedulingApp.Helper;
using DoctorAppointmentSchedulingApp.Models;
using DoctorAppointmentSchedulingApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DoctorAppointmentSchedulingApp.Controllers.API
{
    //This is an Api controller 
    [Route("api/Appointment")]
    [ApiController]
    public class AppointmentApiController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string loginUserId;
        private readonly string role;

        public AppointmentApiController(IAppointmentService appointmentService, IHttpContextAccessor httpContextAccessor)
        {
            _appointmentService = appointmentService;
            _httpContextAccessor = httpContextAccessor;
            loginUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            role = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
       
        
        }

        [HttpPost]
        [Route("SaveCalendarData")]
        public IActionResult SaveCalendarData([FromBody] AppointmentViewModel data)
        {
            CommonResponse<int> commonResponse = new CommonResponse<int>();
            try
            {
                commonResponse.Status = _appointmentService.AddUpdate(data).Result;
                if (commonResponse.Status == 1)
                {
                    commonResponse.Message = Utility.appointmentUpdated;
                }
                if (commonResponse.Status == 2)
                {
                    commonResponse.Message = Utility.appointmentAdded;
                }
            }
            catch (Exception e)
            {
                commonResponse.Message = e.Message;
                commonResponse.Status = Utility.failure_code;
            }

            return Ok(commonResponse);
        }
        [HttpGet]
        [Route("GetCalendarData")]
        public IActionResult GetCalendarData(string doctorId)
        {
            CommonResponse<List<AppointmentViewModel>> commonResponse = new CommonResponse<List<AppointmentViewModel>>();
            try
            {
                //Retuning Appointment details for Patient
                if (role == Roles.Patient)                     
                {
                    commonResponse.dataenum= _appointmentService.PatientsEventById(loginUserId);
                    commonResponse.Status = Utility.success_code;
                }
                //Retuning Appointment details for Patient
                else if (role == Roles.Doctor)                  
                {
                    commonResponse.dataenum = _appointmentService.DoctorsEventById(loginUserId);
                    commonResponse.Status = Utility.success_code;
                }
                //Retuning Appointment details for Admin
                else
                {
                    commonResponse.dataenum = _appointmentService.DoctorsEventById(doctorId);
                    commonResponse.Status = Utility.success_code;
                }                
            }
            catch (Exception e)
            {
                commonResponse.Message = e.Message;
                commonResponse.Status = Utility.failure_code;
            }
            return Ok(commonResponse);
        }

        [HttpGet]
        [Route("GetCalendarDataById/{id}")]
        public IActionResult GetCalendarDataById(int id)
        {
            CommonResponse<AppointmentViewModel> commonResponse = new CommonResponse<AppointmentViewModel>();
            try
            {
                
                    commonResponse.dataenum = _appointmentService.GetById(id);
                    commonResponse.Status = Utility.success_code;
            }
            catch (Exception e)
            {
                commonResponse.Message = e.Message;
                commonResponse.Status = Utility.failure_code;
            }
            return Ok(commonResponse);
        }
    }
}
