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
    [ViewComponent(Name = "Index")]
    public class IndexViewComponent:ViewComponent
    {
        private readonly Webbanhang db;
        public IndexViewComponent(Webbanhang context)
        {
            db = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(
        string id)
        {
            string MyView = "Default";
            switch (id)
            {
                case "3CE":
                    MyView = "NewProduct"; break;
                case "MERZY ":
                    MyView = "LastesProduct"; break;
                default:
                    MyView = "BestSeller"; break;
            }

            var items = await LaySanPham(id);
            return View(MyView,items);
        }
        private async Task<List<SanPhamModel>> LaySanPham(string id)
        {
            var sanPhamList = await db.SanPham.Where(x => x.IDHangsx == id).Take(4).ToListAsync();
            return sanPhamList;
        }

    }
}
