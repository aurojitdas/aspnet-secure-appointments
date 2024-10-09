using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppointmentScheduling1.Helper
{
    public static class Roles
    {
        public static string Admin = "Admin";
        public static string Patient = "Patient";
        public static string Doctor = "Doctor";

        public static List<SelectListItem> getRolesDropDown()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = Admin, Text = Admin },
                new SelectListItem { Value = Patient, Text = Patient },
                new SelectListItem { Value = Doctor, Text = Doctor }

            };
        }

    }
}