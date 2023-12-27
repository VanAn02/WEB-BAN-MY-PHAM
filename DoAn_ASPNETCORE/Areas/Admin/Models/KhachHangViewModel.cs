using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_ASPNETCORE.Areas.Admin.Models
{
    public class KhachHangViewModel
    {
        public List<KhachHangModel> Users { get; set; }
        public SelectList DSUser { get; set; }
        public string User { get; set; }
        public string searchString { get; set; }
    }
}
