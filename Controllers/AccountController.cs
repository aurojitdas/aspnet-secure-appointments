using AppointmentScheduling1.Helper;
using AppointmentScheduling1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentScheduling1.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        UserManager<ApplicationUser> _userManager; //Adding userManager context for the Users.
        SignInManager<ApplicationUser> _signInManager; //Adding signInManager context for the signin.
        RoleManager<IdentityRole> _roleManager; //Adding roleManager context for the signin.

        public AccountController(ApplicationDbContext db, UserManager<ApplicationUser> userManager,
                    SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }

        public IActionResult Login()
        {

            return View();
        }

        public async Task<IActionResult> Register()
        {
            //Validating if the Admin role is already present
            if (!_roleManager.RoleExistsAsync(Roles.Admin).GetAwaiter().GetResult())
            {
                await _roleManager.CreateAsync(new IdentityRole(Roles.Admin));
                await _roleManager.CreateAsync(new IdentityRole(Roles.Patient));
                await _roleManager.CreateAsync(new IdentityRole(Roles.Doctor));

            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]  //Adding this for validating the anti-forgery token for the forms
        public async Task<IActionResult> Register(RegisterViewModel model)  //adding Async and task bcz we are calling await
        {

            if (ModelState.IsValid)
            {

                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name,
                };
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.roleName);
                    await _signInManager.SignInAsync(user, isPersistent: false);   //signing in the default user
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
    }
}
