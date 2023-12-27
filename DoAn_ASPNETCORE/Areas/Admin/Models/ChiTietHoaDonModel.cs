using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_ASPNETCORE.Areas.Admin.Models
{
    public class ChiTietHoaDonModel
    {
        public int ID { get; set; }
        public int IDHoaDon { get; set; }
        [ForeignKey("IDHoaDon")]

        public virtual HoaDonModel HoaDon { set; get; }

        public int IDSP { get; set; }
        public string SoLuong { get; set; }
        public string Gia { get; set; }
    }
}
