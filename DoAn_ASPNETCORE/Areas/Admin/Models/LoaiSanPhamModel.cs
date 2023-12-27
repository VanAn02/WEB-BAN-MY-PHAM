using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_ASPNETCORE.Areas.Admin.Models
{
    public class LoaiSanPhamModel
    {
        [Key]
        public int ID { get; set; }
        public int IDMaLoai { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng nhập tên loại")]
        [StringLength(maximumLength: 50, ErrorMessage = "Tên loại 50 kí tự")]
        public string TenLoai { get; set; }
      
        public ICollection<SanPhamModel> lstSanPham { set; get; }
    
    }
}
