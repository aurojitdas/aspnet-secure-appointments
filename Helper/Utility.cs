using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoctorAppointmentSchedulingApp.Helper
{
    public static class Utility
    {
        public static string appointmentAdded = "Appointment Added Successfully";
        public static string appointmentUpdated = "Appointment Updated Successfully";
        public static string appointmentDeleted = "Appointment Deleted Successfully";
        public static string appointmentExists = "Appointment For selected Date and Time Already Exists";
        public static string appointmentNotExists = "Appointment not exists";

        public static string appointmentAddError = "Something went wrong, Please try again.";
        public static string appointmentUpdateError = "Something went wrong, Please try again.";
        public static string somethingWentWrong = "Something went wrong, Please try again.";

        public static int success_code = 1;
        public static int failure_code = 0;

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
