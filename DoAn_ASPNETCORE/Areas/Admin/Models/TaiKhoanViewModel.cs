using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_ASPNETCORE.Areas.Admin.Models
{
    public class TaiKhoanViewModel
    {
        public List<TaiKhoanModel> Taikhoans { get; set; }
        public SelectList DSTaikhoan { get; set; }
        public string Taikhoan { get; set; }
        public string searchString { get; set; }
    }
}
