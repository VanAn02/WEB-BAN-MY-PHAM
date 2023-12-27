using DoAn_ASPNETCORE.Areas.Admin.Data;
using DoAn_ASPNETCORE.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DoAn_ASPNETCORE.ViewComponents
{
    [ViewComponent(Name = "Son")]
    public class SonViewComponent:ViewComponent
    {
        private readonly Webbanhang db;
        public SonViewComponent(Webbanhang context)
        {
            db = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(
        int id)
        {
            string MyView = "Son";
           
            var items = await LaySanPham(id);

            return View(MyView, items);
        }
        private Task<List<SanPhamModel>> LaySanPham(int id)
        {
            return db.SanPham.Where(x => x.IDMaLoai == id).ToListAsync();
        }
    }

}
