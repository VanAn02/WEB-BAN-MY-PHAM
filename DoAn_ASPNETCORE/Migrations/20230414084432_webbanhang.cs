using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAn_ASPNETCORE.Migrations
{
    public partial class webbanhang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HangSanXuat",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDMaHangsx = table.Column<int>(nullable: false),
                    TenHangsx = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangSanXuat", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSanPham",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDMaLoai = table.Column<int>(nullable: false),
                    TenLoai = table.Column<string>(maxLength: 50, nullable: false),
                    HangSanXuatModelID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSanPham", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LoaiSanPham_HangSanXuat_HangSanXuatModelID",
                        column: x => x.HangSanXuatModelID,
                        principalTable: "HangSanXuat",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Makh = table.Column<int>(nullable: false),
                    HoTen = table.Column<string>(nullable: true),
                    DiaChi = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Sdt = table.Column<string>(nullable: true),
                    TaiKhoanModelID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KhachHang_TaiKhoan_TaiKhoanModelID",
                        column: x => x.TaiKhoanModelID,
                        principalTable: "TaiKhoan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDSP = table.Column<int>(nullable: false),
                    TenSP = table.Column<string>(nullable: true),
                    IDMaLoai = table.Column<int>(nullable: false),
                    IDHangsx = table.Column<string>(nullable: true),
                    Gia = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Image_List = table.Column<string>(nullable: true),
                    SoLuong = table.Column<int>(nullable: false),
                    MoTa = table.Column<string>(nullable: true),
                    NgayLap = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SanPham_LoaiSanPham_IDMaLoai",
                        column: x => x.IDMaLoai,
                        principalTable: "LoaiSanPham",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDKhachHang = table.Column<int>(nullable: false),
                    HoTen = table.Column<string>(nullable: true),
                    Sdt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HoaDon_KhachHang_IDKhachHang",
                        column: x => x.IDKhachHang,
                        principalTable: "KhachHang",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDon",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDHoaDon = table.Column<int>(nullable: false),
                    IDSP = table.Column<int>(nullable: false),
                    SoLuong = table.Column<string>(nullable: true),
                    Gia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDon", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDon_HoaDon_IDHoaDon",
                        column: x => x.IDHoaDon,
                        principalTable: "HoaDon",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_IDHoaDon",
                table: "ChiTietHoaDon",
                column: "IDHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_IDKhachHang",
                table: "HoaDon",
                column: "IDKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_TaiKhoanModelID",
                table: "KhachHang",
                column: "TaiKhoanModelID");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiSanPham_HangSanXuatModelID",
                table: "LoaiSanPham",
                column: "HangSanXuatModelID");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_IDMaLoai",
                table: "SanPham",
                column: "IDMaLoai");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHoaDon");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "LoaiSanPham");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "HangSanXuat");

            migrationBuilder.DropTable(
                name: "TaiKhoan");
        }
    }
}
