using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_ASPNETCORE.Areas.Admin.Models
{
    public class HoaDonModel
    {
        public int ID { get; set; }
        public int IDKhachHang { get; set; }
        [ForeignKey("IDKhachHang")]
        public virtual KhachHangModel KhachHang { set; get; }
        public string HoTen { get; set; }
        public string Sdt { get; set; }

        public ICollection<ChiTietHoaDonModel> lstCTHD { set; get; }
    }
}
