﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoctorAppointmentSchedulingApp.Helper
{
    public static class Utility
    {
        public static List<SelectListItem> GetTimeDropDown()
        {
            int minute = 60;
            List<SelectListItem> duration = new List<SelectListItem>();
            for(int i = 1; i <= 12; i++)
            {
                duration.Add(new SelectListItem { Value = minute.ToString(), Text = i + " Hr" });
                minute = minute + 30;
                duration.Add(new SelectListItem { Value = minute.ToString(), Text = i + " Hr 30 Min" });
                minute = minute + 30;
            }
            return duration;
        }

    }
}
