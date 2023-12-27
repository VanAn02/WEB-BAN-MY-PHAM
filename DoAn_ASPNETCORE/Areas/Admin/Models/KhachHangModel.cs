using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_ASPNETCORE.Areas.Admin.Models
{
    public class KhachHangModel
    {
        public int ID { get; set; }
        public int Makh { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string Sdt { get; set; }

        public ICollection<HoaDonModel> lstHoaDon { set; get; }
        
    }
}
