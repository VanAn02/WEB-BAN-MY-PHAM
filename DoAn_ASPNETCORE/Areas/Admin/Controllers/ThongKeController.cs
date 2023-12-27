using DoAn_ASPNETCORE.Areas.Admin.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_ASPNETCORE.Areas.Admin.Controllers
{

    public class ThongKeController : Controller
    {
        private readonly Webbanhang _context;

        public ThongKeController(Webbanhang context)
        {
            _context = context;
        }
        
    }
}
