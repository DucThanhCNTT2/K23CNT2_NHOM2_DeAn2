using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hethonglaptop_prj2.Migrations
{
    /// <inheritdoc />
    public partial class AddAnhToSanPham : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    MaKH = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__KhachHan__2725CF1E390684AD", x => x.MaKH);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    MaNV = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ChucVu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NhanVien__2725D70A81434F61", x => x.MaNV);
                });

            migrationBuilder.CreateTable(
                name: "ThuongHieu",
                columns: table => new
                {
                    MaTH = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenTH = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    QuocGia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ThuongHi__272500750F3AB2AC", x => x.MaTH);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    MaHD = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NgayLap = table.Column<DateOnly>(type: "date", nullable: false),
                    MaKH = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MaNV = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TongTien = table.Column<decimal>(type: "decimal(15,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HoaDon__2725A6E0D46DCB2F", x => x.MaHD);
                    table.ForeignKey(
                        name: "FK__HoaDon__MaKH__440B1D61",
                        column: x => x.MaKH,
                        principalTable: "KhachHang",
                        principalColumn: "MaKH");
                    table.ForeignKey(
                        name: "FK__HoaDon__MaNV__44FF419A",
                        column: x => x.MaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV");
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    MaSP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenSP = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaTH = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Anh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SanPham__2725081C5884B0E7", x => x.MaSP);
                    table.ForeignKey(
                        name: "FK__SanPham__MaTH__3A81B327",
                        column: x => x.MaTH,
                        principalTable: "ThuongHieu",
                        principalColumn: "MaTH");
                });

            migrationBuilder.CreateTable(
                name: "CTHoaDon",
                columns: table => new
                {
                    MaHD = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaSP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(15,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CTHoaDon__F557F6615E895F33", x => new { x.MaHD, x.MaSP });
                    table.ForeignKey(
                        name: "FK__CTHoaDon__MaHD__47DBAE45",
                        column: x => x.MaHD,
                        principalTable: "HoaDon",
                        principalColumn: "MaHD",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__CTHoaDon__MaSP__48CFD27E",
                        column: x => x.MaSP,
                        principalTable: "SanPham",
                        principalColumn: "MaSP");
                });

            migrationBuilder.CreateTable(
                name: "Laptop",
                columns: table => new
                {
                    MaSP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CPU = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RAM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OCung = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CardDoHoa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HeDieuHanh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ManHinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Laptop__2725081C089C7E1A", x => x.MaSP);
                    table.ForeignKey(
                        name: "FK__Laptop__MaSP__3D5E1FD2",
                        column: x => x.MaSP,
                        principalTable: "SanPham",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CTHoaDon_MaSP",
                table: "CTHoaDon",
                column: "MaSP");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_MaKH",
                table: "HoaDon",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_MaNV",
                table: "HoaDon",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_MaTH",
                table: "SanPham",
                column: "MaTH");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CTHoaDon");

            migrationBuilder.DropTable(
                name: "Laptop");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "ThuongHieu");
        }
    }
}
