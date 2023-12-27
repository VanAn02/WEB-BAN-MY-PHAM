using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_ASPNETCORE.Areas.Admin.Models
{
    public class SanPhamModel
    {
        public int ID { get; set; }
        public int IDSP { get; set; }
        public string TenSP { get; set; }
        public int IDMaLoai { get; set; }
        [ForeignKey("IDMaLoai")]
        public virtual LoaiSanPhamModel Loai { set; get; }

        public String IDHangsx { get; set; }
        public int Gia { get; set; }
        public string Image { get; set; }
        public string Image_List { get; set; }
        public int SoLuong { get; set; }
        public string MoTa { get; set; }
        public DateTime NgayLap { get; set; }


    }
}
