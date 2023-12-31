﻿using System;
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
    public class LoaiSanPhamController : Controller
    {
        private readonly Webbanhang _context;

        public LoaiSanPhamController(Webbanhang context)
        {
            _context = context;
        }

        // GET: Admin/LoaiSanPham
        public async Task<IActionResult> Index(/*string SearchString*/)
        {

            
            return View();

        }

        // GET: Admin/LoaiSanPham/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiSanPhamModel = await _context.LoaiSanPham
                .FirstOrDefaultAsync(m => m.ID == id);
            if (loaiSanPhamModel == null)
            {
                return NotFound();
            }

            return View(loaiSanPhamModel);
        }

        // GET: Admin/LoaiSanPham/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiSanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IDMaLoai,TenLoai")] LoaiSanPhamModel loaiSanPhamModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiSanPhamModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiSanPhamModel);
        }

        // GET: Admin/LoaiSanPham/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiSanPhamModel = await _context.LoaiSanPham.FindAsync(id);
            if (loaiSanPhamModel == null)
            {
                return NotFound();
            }
            return View(loaiSanPhamModel);
        }

        // POST: Admin/LoaiSanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IDMaLoai,TenLoai")] LoaiSanPhamModel loaiSanPhamModel)
        {
            if (id != loaiSanPhamModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiSanPhamModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiSanPhamModelExists(loaiSanPhamModel.ID))
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
            return View(loaiSanPhamModel);
        }

        // GET: Admin/LoaiSanPham/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiSanPhamModel = await _context.LoaiSanPham
                .FirstOrDefaultAsync(m => m.ID == id);
            if (loaiSanPhamModel == null)
            {
                return NotFound();
            }

            return View(loaiSanPhamModel);
        }

        // POST: Admin/LoaiSanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaiSanPhamModel = await _context.LoaiSanPham.FindAsync(id);
            _context.LoaiSanPham.Remove(loaiSanPhamModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiSanPhamModelExists(int id)
        {
            return _context.LoaiSanPham.Any(e => e.ID == id);
        }
    }
}
