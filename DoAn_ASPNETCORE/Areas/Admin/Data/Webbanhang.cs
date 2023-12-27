using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAn_ASPNETCORE.Areas.Admin.Models;

namespace DoAn_ASPNETCORE.Areas.Admin.Data
{
    public class Webbanhang :DbContext
    {
        public Webbanhang(DbContextOptions<Webbanhang>options)
            :base(options)
        {

        }
        public DbSet<DoAn_ASPNETCORE.Areas.Admin.Models.SanPhamModel> SanPham { get; set; }
        public DbSet<DoAn_ASPNETCORE.Areas.Admin.Models.LoaiSanPhamModel> LoaiSanPham { get; set; }
        public DbSet<DoAn_ASPNETCORE.Areas.Admin.Models.HoaDonModel> HoaDon { get; set; }
        public DbSet<DoAn_ASPNETCORE.Areas.Admin.Models.ChiTietHoaDonModel> ChiTietHoaDon { get; set; }
        public DbSet<DoAn_ASPNETCORE.Areas.Admin.Models.KhachHangModel> KhachHang { get; set; }
        public DbSet<DoAn_ASPNETCORE.Areas.Admin.Models.HangSanXuatModel> HangSanXuat { get; set; }
        public DbSet<DoAn_ASPNETCORE.Areas.Admin.Models.TaiKhoanModel> TaiKhoan { get; set; }
        
    }
}
