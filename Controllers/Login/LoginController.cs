using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Celsia.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Celsia.Data;
using Microsoft.EntityFrameworkCore;
using Celsia.DTO;

public class LoginController : Controller
{
        private readonly ILogger<LoginController> _logger;
        private readonly DataContext _context;

        public LoginController(ILogger<LoginController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

            public IActionResult Login()
            {
                return View();
            }
            

        
            [HttpPost]
            public async Task<IActionResult> Login(userDTO model)
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var user = await _context.UsersAuthentications.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);

                if (user != null)
                {
                    
                    HttpContext.Session.SetString("Email", user.Email);
                    HttpContext.Session.SetString("Auth", "Yes");
                    HttpContext.Session.SetString("Username", user.UserName);

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "contraseña o correo incorrectos");
                return View(model);
            }
}




