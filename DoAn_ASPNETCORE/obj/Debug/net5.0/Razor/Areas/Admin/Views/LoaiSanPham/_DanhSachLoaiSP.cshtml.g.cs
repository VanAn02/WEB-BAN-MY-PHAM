#pragma checksum "D:\D\LẬP TRÌNH NET NÂNG CAO\BTL\DoAn_ASPNETCORE\DoAn_ASPNETCORE\DoAn_ASPNETCORE\Areas\Admin\Views\LoaiSanPham\_DanhSachLoaiSP.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2480c355335ce90e527068793a1fa00178b26e4e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_LoaiSanPham__DanhSachLoaiSP), @"mvc.1.0.view", @"/Areas/Admin/Views/LoaiSanPham/_DanhSachLoaiSP.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\D\LẬP TRÌNH NET NÂNG CAO\BTL\DoAn_ASPNETCORE\DoAn_ASPNETCORE\DoAn_ASPNETCORE\Areas\Admin\Views\_ViewImports.cshtml"
using DoAn_ASPNETCORE;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\D\LẬP TRÌNH NET NÂNG CAO\BTL\DoAn_ASPNETCORE\DoAn_ASPNETCORE\DoAn_ASPNETCORE\Areas\Admin\Views\_ViewImports.cshtml"
using DoAn_ASPNETCORE.Areas.Admin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2480c355335ce90e527068793a1fa00178b26e4e", @"/Areas/Admin/Views/LoaiSanPham/_DanhSachLoaiSP.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb86231ad250d79601aca30bf4d3cfeb837cad47", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_LoaiSanPham__DanhSachLoaiSP : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DoAn_ASPNETCORE.Areas.Admin.Models.LoaiSanPhamModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("        <table class=\"table\">\r\n            <thead>\r\n                <tr>\r\n                    <th>\r\n                        ");
#nullable restore
#line 6 "D:\D\LẬP TRÌNH NET NÂNG CAO\BTL\DoAn_ASPNETCORE\DoAn_ASPNETCORE\DoAn_ASPNETCORE\Areas\Admin\Views\LoaiSanPham\_DanhSachLoaiSP.cshtml"
                   Write(Html.DisplayNameFor(model => model.IDMaLoai));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 9 "D:\D\LẬP TRÌNH NET NÂNG CAO\BTL\DoAn_ASPNETCORE\DoAn_ASPNETCORE\DoAn_ASPNETCORE\Areas\Admin\Views\LoaiSanPham\_DanhSachLoaiSP.cshtml"
                   Write(Html.DisplayNameFor(model => model.TenLoai));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    \r\n                    <th></th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n                <div id=\"dsloaisp\">\r\n");
#nullable restore
#line 17 "D:\D\LẬP TRÌNH NET NÂNG CAO\BTL\DoAn_ASPNETCORE\DoAn_ASPNETCORE\DoAn_ASPNETCORE\Areas\Admin\Views\LoaiSanPham\_DanhSachLoaiSP.cshtml"
                     foreach (var item in ViewBag.DsLoaiSP)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
#nullable restore
#line 21 "D:\D\LẬP TRÌNH NET NÂNG CAO\BTL\DoAn_ASPNETCORE\DoAn_ASPNETCORE\DoAn_ASPNETCORE\Areas\Admin\Views\LoaiSanPham\_DanhSachLoaiSP.cshtml"
                           Write(item.IDMaLoai);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 24 "D:\D\LẬP TRÌNH NET NÂNG CAO\BTL\DoAn_ASPNETCORE\DoAn_ASPNETCORE\DoAn_ASPNETCORE\Areas\Admin\Views\LoaiSanPham\_DanhSachLoaiSP.cshtml"
                           Write(item.TenLoai);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                           \r\n                            <td>\r\n                                <button type=\"button\" name=\"edit_loaisanpham\" data-idloaisp=\"");
#nullable restore
#line 28 "D:\D\LẬP TRÌNH NET NÂNG CAO\BTL\DoAn_ASPNETCORE\DoAn_ASPNETCORE\DoAn_ASPNETCORE\Areas\Admin\Views\LoaiSanPham\_DanhSachLoaiSP.cshtml"
                                                                                        Write(item.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""" class=""btn btn-primary"" data-toggle=""modal"" data-target=""#EditModal"">Edit</button>
                                <button type=""button"" name=""edit_loaisanpham"" data-idloaisp=""20"" class=""btn btn-primary"" data-toggle=""modal"" data-target=""#EditModal"">Edit</button>
                                <button type=""button"" name=""btn_delete_loaisanpham"" data-idloaisp=""");
#nullable restore
#line 30 "D:\D\LẬP TRÌNH NET NÂNG CAO\BTL\DoAn_ASPNETCORE\DoAn_ASPNETCORE\DoAn_ASPNETCORE\Areas\Admin\Views\LoaiSanPham\_DanhSachLoaiSP.cshtml"
                                                                                              Write(item.ID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"btn btn-danger\">Delete</button>\r\n                                <button type=\"button\" name=\"btn_delete_loaisanpham\" data-idloaisp=\"20\" class=\"btn btn-danger\">Delete</button>\r\n\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 35 "D:\D\LẬP TRÌNH NET NÂNG CAO\BTL\DoAn_ASPNETCORE\DoAn_ASPNETCORE\DoAn_ASPNETCORE\Areas\Admin\Views\LoaiSanPham\_DanhSachLoaiSP.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </tbody>\r\n        </table>\r\n   ");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DoAn_ASPNETCORE.Areas.Admin.Models.LoaiSanPhamModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
