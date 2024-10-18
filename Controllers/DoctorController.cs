﻿using AppointmentScheduling1.Models;
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
            return View(doctorList);
        }

        public IActionResult Update(String id)

        {
            var doctor = _DB.Users.Find(id);

            if (doctor == null)
            {
                return NotFound();
            }
            else
            {
                var DoctorVM = new DoctorViewModel();
                DoctorVM.Id = doctor.Id;
                DoctorVM.userName = doctor.UserName;
                DoctorVM.assignmentStatus = doctor.assignMentStatus;
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
                doctor.assignMentStatus = doctorVM.assignmentStatus;
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
