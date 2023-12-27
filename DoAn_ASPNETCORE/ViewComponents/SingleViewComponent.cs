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
    [ViewComponent(Name = "Single")]
    public class SingleViewComponent : ViewComponent
    {
        private readonly Webbanhang db;
        public SingleViewComponent(Webbanhang context)
        {
            db = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(
       int id)
        {
            string MyView = "Single";

            var items = await LayRecent(id);

            return View(MyView, items);
         
        }
     
        private Task<List<SanPhamModel>> LayRecent(int id)
        {
            return db.SanPham.Where(x => x.IDMaLoai == id).ToListAsync();
        }
        
    }
}
