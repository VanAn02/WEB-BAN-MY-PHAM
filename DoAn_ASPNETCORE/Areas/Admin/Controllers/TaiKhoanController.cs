using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAn_ASPNETCORE.Areas.Admin.Data;
using DoAn_ASPNETCORE.Areas.Admin.Models;
using System.Text;
using System.Security.Cryptography;

namespace DoAn_ASPNETCORE.Areas.Admin.Controllers
{
    public class TaiKhoanController : Controller
    {
        private readonly Webbanhang _context;

        public TaiKhoanController(Webbanhang context)
        {
            _context = context;
        }
        // GET: TaiKhoanController
        public ActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tkModel = await _context.TaiKhoan
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tkModel == null)
            {
                return NotFound();
            }

            return View(tkModel);

        }
        public IActionResult Create()
        {
            return View();
        }



        // POST: Admin/User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserName,Password,IsAdmin")] TaiKhoanModel tkModel)
        {
            if (ModelState.IsValid)
            {
                tkModel.Password = CreateMd5(tkModel.Password);
                _context.Add(tkModel);
                await _context.SaveChangesAsync();
                var url = Url.RouteUrl("", new { Controller = "Pages", action = "Index", area = "" });
                return Redirect(url);
            }
            return View(tkModel);
        }

        public static string CreateMd5(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hasBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hasBytes.Length; i++)
            {
                sb.Append(hasBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
        // GET: Admin/User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tkModel = await _context.TaiKhoan.FindAsync(id);
            if (tkModel == null)
            {
                return NotFound();
            }
            return View(tkModel);
        }

        // POST: Admin/User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserName,Password,IsAdmin")] TaiKhoanModel tkModel)
        {
            if (id != tkModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tkModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserModelExists(tkModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tkModel);
        }

        // GET: Admin/User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tkModel = await _context.TaiKhoan
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tkModel == null)
            {
                return NotFound();
            }

            return View(tkModel);
        }

        // POST: Admin/User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tkModel = await _context.TaiKhoan.FindAsync(id);
            _context.TaiKhoan.Remove(tkModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserModelExists(int id)
        {
            return _context.TaiKhoan.Any(e => e.ID == id);
        }
    }
}
