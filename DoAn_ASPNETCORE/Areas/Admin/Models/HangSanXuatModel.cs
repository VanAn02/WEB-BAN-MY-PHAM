
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_ASPNETCORE.Areas.Admin.Models
{
    public class HangSanXuatModel
    {
        public int ID { get; set; }
        public int IDMaHangsx { get; set; }
        public string TenHangsx { get; set; }
        public ICollection<LoaiSanPhamModel> lstLoaiSanPham { set; get; }
    }
}
