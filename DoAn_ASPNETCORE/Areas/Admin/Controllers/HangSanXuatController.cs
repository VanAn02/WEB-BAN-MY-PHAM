using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAn_ASPNETCORE.Areas.Admin.Data;
using DoAn_ASPNETCORE.Areas.Admin.Models;

namespace DoAn_ASPNETCORE.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HangSanXuatController : Controller
    {
        private readonly Webbanhang _context;

        public HangSanXuatController(Webbanhang context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {

            return View();
        }

        // GET: Admin/NhaCungCap/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangSanXuatModel = await _context.HangSanXuat
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hangSanXuatModel == null)
            {
                return NotFound();
            }

            return View(hangSanXuatModel);
        }

        // GET: Admin/NhaCungCap/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhaCungCap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MaHangsx,TenHangsx")] HangSanXuatModel hangSanXuatModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hangSanXuatModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hangSanXuatModel);
        }

        // GET: Admin/NhaCungCap/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangSanXuatModel = await _context.HangSanXuat.FindAsync(id);
            if (hangSanXuatModel == null)
            {
                return NotFound();
            }
            return View(hangSanXuatModel);
        }

        // POST: Admin/NhaCungCap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MaHangsx,TenHangsx")] HangSanXuatModel hangSanXuatModel)
        {
            if (id != hangSanXuatModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hangSanXuatModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhaCungCapModelExists(hangSanXuatModel.ID))
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
            return View(hangSanXuatModel);
        }

        // GET: Admin/NhaCungCap/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangSanXuatModel = await _context.HangSanXuat
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hangSanXuatModel == null)
            {
                return NotFound();
            }

            return View(hangSanXuatModel);
        }

        // POST: Admin/NhaCungCap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hangSanXuatModel = await _context.HangSanXuat.FindAsync(id);
            _context.HangSanXuat.Remove(hangSanXuatModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhaCungCapModelExists(int id)
        {
            return _context.HangSanXuat.Any(e => e.ID == id);
        }
    }
}
