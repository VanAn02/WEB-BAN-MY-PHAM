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
    public class HoaDonController : Controller
    {
        private readonly Webbanhang _context;

        public HoaDonController(Webbanhang context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            ViewData["IDKhachHang"] = new SelectList(_context.Set<KhachHangModel>(), "ID", "UserName");
            return View();
        }


        // GET: Admin/HoaDon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDonModel = await _context.HoaDon
                .Include(h => h.KhachHang)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hoaDonModel == null)
            {
                return NotFound();
            }

            return View(hoaDonModel);
        }

        // GET: Admin/HoaDon/Create
        public IActionResult Create()
        {
            ViewData["IDKhachHang"] = new SelectList(_context.Set<KhachHangModel>(), "ID", "ID");
            return View();
        }

        // POST: Admin/HoaDon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IDKhacHang,HoTen,Sdt")] HoaDonModel hoaDonModel, [Bind("ID,IDHoaDon,IDSP,SoLuong,Gia")] ChiTietHoaDonModel chitiethoaDonModel)
        {
            var HoaDon = from m in _context.HoaDon
                         select m;
            int size = HoaDon.Count();
            if (ModelState.IsValid)
            {
                _context.Add(hoaDonModel);
                size++;
                await _context.SaveChangesAsync();
                chitiethoaDonModel.IDHoaDon = size;
                _context.Add(chitiethoaDonModel);
                await _context.SaveChangesAsync();
                HttpContext.Session.Remove("cart");
                var url = Url.RouteUrl(new {area="", controller = "Pages",action="Index"});
                return Redirect(url);
            }
            ViewData["IDKhachHang"] = new SelectList(_context.Set<KhachHangModel>(), "ID", "ID", hoaDonModel.IDKhachHang);
            return View(hoaDonModel);
        }

        // GET: Admin/HoaDon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDonModel = await _context.HoaDon.FindAsync(id);
            if (hoaDonModel == null)
            {
                return NotFound();
            }
            ViewData["IDKhachHang"] = new SelectList(_context.Set<KhachHangModel>(), "ID", "ID", hoaDonModel.IDKhachHang);
            return View(hoaDonModel);
        }

        // POST: Admin/HoaDon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IDKhacHang,HoTen,Sdt")] HoaDonModel hoaDonModel)
        {
            if (id != hoaDonModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoaDonModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoaDonModelExists(hoaDonModel.ID))
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
            ViewData["IDKhachHang"] = new SelectList(_context.Set<KhachHangModel>(), "ID", "ID", hoaDonModel.IDKhachHang);
            return View(hoaDonModel);
        }

        // GET: Admin/HoaDon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDonModel = await _context.HoaDon
                .Include(h => h.KhachHang )
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hoaDonModel == null)
            {
                return NotFound();
            }

            return View(hoaDonModel);
        }

        // POST: Admin/HoaDon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hoaDonModel = await _context.HoaDon.FindAsync(id);
            _context.HoaDon.Remove(hoaDonModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoaDonModelExists(int id)
        {
            return _context.HoaDon.Any(e => e.ID == id);
        }
    }
}
