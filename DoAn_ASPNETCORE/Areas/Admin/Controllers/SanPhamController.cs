﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAn_ASPNETCORE.Areas.Admin.Data;
using DoAn_ASPNETCORE.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace DoAn_ASPNETCORE.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamController : Controller
    {
        private readonly Webbanhang _context;

        public SanPhamController(Webbanhang context)
        {
            _context = context;
        }

        // GET: Admin/SanPham
        public async Task<IActionResult> Index(string searchString)
        {
            IQueryable<string> genreQuery = from m in _context.SanPham select m.TenSP;
            var sanphams = from m in _context.SanPham
                           select m;
            if (!string.IsNullOrEmpty(searchString))
            {
                sanphams = sanphams.Where(s => s.TenSP.Contains(searchString));
            }

            var SanPhamViewModel = new SanPhamViewModel
            {
                SPs = new SelectList(await genreQuery.Distinct().ToListAsync()),
                SanPhams = await sanphams.ToListAsync()

            };
            return View(SanPhamViewModel);
        }

        // GET: Admin/SanPham/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPhamModel = await _context.SanPham
                .Include(s => s.Loai)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sanPhamModel == null)
            {
                return NotFound();
            }

            return View(sanPhamModel);
        }

        // GET: Admin/SanPham/Create
        public IActionResult Create()
        {
            ViewData["MaLoai"] = new SelectList(_context.Set<LoaiSanPhamModel>(), "ID", "ID");
            ViewData["IDMaHangsx"] = new SelectList(_context.Set<HangSanXuatModel>(), "IDMaHangsx", "IDMaHangsx");
            return View();
        }

        // POST: Admin/SanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IDSP,TenSP,IDMaLoai,Gia,Image,Image_List,SoLuong,MoTa,NgayLap")] SanPhamModel sanPhamModel, IFormFile ful, IFormFile ful1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanPhamModel);
                await _context.SaveChangesAsync();
                //dat lai ten file hinh theo ID
                string s = sanPhamModel.ID + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1];
                //Di chuyen file hinh den folder khac
                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot/images/", s);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await ful.CopyToAsync(stream);
                }
                //dat lai ten file hinh theo ID
                string s1 = sanPhamModel.ID + "2nd" + "." + ful1.FileName.Split(".")[ful1.FileName.Split(".").Length - 1] ;
                //Di chuyen file hinh den folder khac
                var path1 = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot/images/", s1);
                using (var stream1 = new FileStream(path1, FileMode.Create))
                {
                    await ful1.CopyToAsync(stream1);
                }
                //Gan lai ten file hinh moi cho cot TenHinh
                sanPhamModel.Image = s;
                sanPhamModel.Image_List = s1;
                _context.Update(sanPhamModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(sanPhamModel);
        }

        // GET: Admin/SanPham/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPhamModel = await _context.SanPham.FindAsync(id);
            if (sanPhamModel == null)
            {
                return NotFound();
            }
            ViewData["IDMaLoai"] = new SelectList(_context.Set<LoaiSanPhamModel>(), "ID", "ID", sanPhamModel.IDMaLoai);
            ViewData["IDMaHangsx"] = new SelectList(_context.Set<HangSanXuatModel>(), "IDMaHangsx", "IDMaHangsx");
            return View(sanPhamModel);
        }

        // POST: Admin/SanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IDSP,TenSP,IDMaLoai,Gia,Image,Image_List,SoLuong,MoTa,NgayLap")] SanPhamModel sanPhamModel, IFormFile ful, IFormFile ful1)
        {
            if (id != sanPhamModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (ful != null)
                    {
                        //Doi ten anh moi thanh ID.jpg

                        string s = sanPhamModel.ID + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1];
                        string ss = sanPhamModel.Image;
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/");
                        if (System.IO.File.Exists(path))
                        {
                            //Kiem tra ten anh moi co trung anh cu khong?
                            //xoa
                            System.IO.File.Delete(path);
                        }
                        //Gan ten anh moi cho path
                        path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", s);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {

                            await ful.CopyToAsync(stream);
                        }
                        //Gan lai anh moi
                        sanPhamModel.Image = s;
                    }
                    if (ful1 != null)
                    {
                        //Doi ten anh moi thanh ID.jpg

                        string s1 = sanPhamModel.ID + "2nd" + "." + ful1.FileName.Split(".")[ful1.FileName.Split(".").Length - 1];
                        var path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/");
                        if (System.IO.File.Exists(path1))
                        {
                            //Kiem tra ten anh moi co trung anh cu khong?
                            //xoa
                            System.IO.File.Delete(path1);
                        }
                        //Gan ten anh moi cho path
                        path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", s1);
                        using (var stream = new FileStream(path1, FileMode.Create))
                        {

                            await ful1.CopyToAsync(stream);
                        }
                        //Gan lai anh moi
                        sanPhamModel.Image_List = s1;
                    }
                    _context.Update(sanPhamModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamModelExists(sanPhamModel.ID))
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
            ViewData["IDMaLoai"] = new SelectList(_context.Set<LoaiSanPhamModel>(), "ID", "ID", sanPhamModel.IDMaLoai);
            return View(sanPhamModel);
        }

        // GET: Admin/SanPham/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPhamModel = await _context.SanPham
                .Include(s => s.Loai)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sanPhamModel == null)
            {
                return NotFound();
            }

            return View(sanPhamModel);
        }

        // POST: Admin/SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanPhamModel = await _context.SanPham.FindAsync(id);
            _context.SanPham.Remove(sanPhamModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamModelExists(int id)
        {
            return _context.SanPham.Any(e => e.ID == id);
        }
    }
}
