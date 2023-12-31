﻿// <auto-generated />
using System;
using DoAn_ASPNETCORE.Areas.Admin.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DoAn_ASPNETCORE.Migrations
{
    [DbContext(typeof(Webbanhang))]
    partial class WebbanhangModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DoAn_ASPNETCORE.Areas.Admin.Models.ChiTietHoaDonModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Gia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IDHoaDon")
                        .HasColumnType("int");

                    b.Property<int>("IDSP")
                        .HasColumnType("int");

                    b.Property<string>("SoLuong")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("IDHoaDon");

                    b.ToTable("ChiTietHoaDon");
                });

            modelBuilder.Entity("DoAn_ASPNETCORE.Areas.Admin.Models.HangSanXuatModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IDMaHangsx")
                        .HasColumnType("int");

                    b.Property<string>("TenHangsx")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("HangSanXuat");
                });

            modelBuilder.Entity("DoAn_ASPNETCORE.Areas.Admin.Models.HoaDonModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IDKhachHang")
                        .HasColumnType("int");

                    b.Property<string>("Sdt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("IDKhachHang");

                    b.ToTable("HoaDon");
                });

            modelBuilder.Entity("DoAn_ASPNETCORE.Areas.Admin.Models.KhachHangModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Makh")
                        .HasColumnType("int");

                    b.Property<string>("Sdt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TaiKhoanModelID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TaiKhoanModelID");

                    b.ToTable("KhachHang");
                });

            modelBuilder.Entity("DoAn_ASPNETCORE.Areas.Admin.Models.LoaiSanPhamModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HangSanXuatModelID")
                        .HasColumnType("int");

                    b.Property<int>("IDMaLoai")
                        .HasColumnType("int");

                    b.Property<string>("TenLoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.HasIndex("HangSanXuatModelID");

                    b.ToTable("LoaiSanPham");
                });

            modelBuilder.Entity("DoAn_ASPNETCORE.Areas.Admin.Models.SanPhamModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Gia")
                        .HasColumnType("int");

                    b.Property<string>("IDHangsx")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IDMaLoai")
                        .HasColumnType("int");

                    b.Property<int>("IDSP")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image_List")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayLap")
                        .HasColumnType("datetime2");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("TenSP")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("IDMaLoai");

                    b.ToTable("SanPham");
                });

            modelBuilder.Entity("DoAn_ASPNETCORE.Areas.Admin.Models.TaiKhoanModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TaiKhoan");
                });

            modelBuilder.Entity("DoAn_ASPNETCORE.Areas.Admin.Models.ChiTietHoaDonModel", b =>
                {
                    b.HasOne("DoAn_ASPNETCORE.Areas.Admin.Models.HoaDonModel", "HoaDon")
                        .WithMany("lstCTHD")
                        .HasForeignKey("IDHoaDon")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DoAn_ASPNETCORE.Areas.Admin.Models.HoaDonModel", b =>
                {
                    b.HasOne("DoAn_ASPNETCORE.Areas.Admin.Models.KhachHangModel", "KhachHang")
                        .WithMany("lstHoaDon")
                        .HasForeignKey("IDKhachHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DoAn_ASPNETCORE.Areas.Admin.Models.KhachHangModel", b =>
                {
                    b.HasOne("DoAn_ASPNETCORE.Areas.Admin.Models.TaiKhoanModel", null)
                        .WithMany("lstKhachHang")
                        .HasForeignKey("TaiKhoanModelID");
                });

            modelBuilder.Entity("DoAn_ASPNETCORE.Areas.Admin.Models.LoaiSanPhamModel", b =>
                {
                    b.HasOne("DoAn_ASPNETCORE.Areas.Admin.Models.HangSanXuatModel", null)
                        .WithMany("lstLoaiSanPham")
                        .HasForeignKey("HangSanXuatModelID");
                });

            modelBuilder.Entity("DoAn_ASPNETCORE.Areas.Admin.Models.SanPhamModel", b =>
                {
                    b.HasOne("DoAn_ASPNETCORE.Areas.Admin.Models.LoaiSanPhamModel", "Loai")
                        .WithMany("lstSanPham")
                        .HasForeignKey("IDMaLoai")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
