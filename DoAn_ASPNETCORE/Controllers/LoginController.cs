using DoAn_ASPNETCORE.Areas.Admin.Data;
using DoAn_ASPNETCORE.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_ASPNETCORE.Controllers
{
    public class LoginController : Controller
    {
        private readonly Webbanhang _context;

        public LoginController(Webbanhang context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Login(TaiKhoanModel user)
        {
            var validUser = _context.TaiKhoan
                .FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);

            if (validUser != null)
            {
                HttpContext.Session.SetString("UserName", user.UserName);
                HttpContext.Session.SetInt32("IDKhachHang", validUser.ID);

                if (validUser.IsAdmin)
                {
                    return RedirectToAction(nameof(Index), "Admin");
                }
                else
                {
                    return RedirectToAction(nameof(Index), "Pages");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(user);
            }
        }

        // GET: TaiKhoan/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }
    }
}

