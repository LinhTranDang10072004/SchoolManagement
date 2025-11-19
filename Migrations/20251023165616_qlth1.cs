using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyTruongHocV1.Migrations
{
    /// <inheritdoc />
    public partial class qlth1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HocKys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NamHoc = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    KyThu = table.Column<int>(type: "int", nullable: false),
                    DaKhoa = table.Column<bool>(type: "bit", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocKys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonHocs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    HeSo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHocs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nguoi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    DienThoai = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Loai = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nguoi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhoiMons",
                columns: table => new
                {
                    Khoi = table.Column<int>(type: "int", nullable: false),
                    MonHocId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoiMons", x => new { x.Khoi, x.MonHocId });
                    table.ForeignKey(
                        name: "FK_KhoiMons_MonHocs_MonHocId",
                        column: x => x.MonHocId,
                        principalTable: "MonHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HocSinhId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MonHocId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HocKyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GiaTri = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diems_HocKys_HocKyId",
                        column: x => x.HocKyId,
                        principalTable: "HocKys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diems_MonHocs_MonHocId",
                        column: x => x.MonHocId,
                        principalTable: "MonHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diems_Nguoi_HocSinhId",
                        column: x => x.HocSinhId,
                        principalTable: "Nguoi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiemThanhPhans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HocSinhId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MonHocId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HocKyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Loai = table.Column<int>(type: "int", nullable: false),
                    GiaTri = table.Column<double>(type: "float", nullable: false),
                    NgayNhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GiaoVienId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiemThanhPhans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiemThanhPhans_HocKys_HocKyId",
                        column: x => x.HocKyId,
                        principalTable: "HocKys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiemThanhPhans_MonHocs_MonHocId",
                        column: x => x.MonHocId,
                        principalTable: "MonHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiemThanhPhans_Nguoi_GiaoVienId",
                        column: x => x.GiaoVienId,
                        principalTable: "Nguoi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiemThanhPhans_Nguoi_HocSinhId",
                        column: x => x.HocSinhId,
                        principalTable: "Nguoi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LopHocs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Khoi = table.Column<int>(type: "int", nullable: false),
                    GVCNId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LopHocs_Nguoi_GVCNId",
                        column: x => x.GVCNId,
                        principalTable: "Nguoi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GhiDanhs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HocSinhId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LopHocId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HocKyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GhiDanhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GhiDanhs_HocKys_HocKyId",
                        column: x => x.HocKyId,
                        principalTable: "HocKys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GhiDanhs_LopHocs_LopHocId",
                        column: x => x.LopHocId,
                        principalTable: "LopHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GhiDanhs_Nguoi_HocSinhId",
                        column: x => x.HocSinhId,
                        principalTable: "Nguoi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhanCongs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GiaoVienId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MonHocId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LopHocId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HocKyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanCongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhanCongs_HocKys_HocKyId",
                        column: x => x.HocKyId,
                        principalTable: "HocKys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhanCongs_LopHocs_LopHocId",
                        column: x => x.LopHocId,
                        principalTable: "LopHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhanCongs_MonHocs_MonHocId",
                        column: x => x.MonHocId,
                        principalTable: "MonHocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhanCongs_Nguoi_GiaoVienId",
                        column: x => x.GiaoVienId,
                        principalTable: "Nguoi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diems_HocKyId",
                table: "Diems",
                column: "HocKyId");

            migrationBuilder.CreateIndex(
                name: "IX_Diems_HocSinhId_MonHocId_HocKyId",
                table: "Diems",
                columns: new[] { "HocSinhId", "MonHocId", "HocKyId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diems_MonHocId",
                table: "Diems",
                column: "MonHocId");

            migrationBuilder.CreateIndex(
                name: "IX_DiemThanhPhans_GiaoVienId",
                table: "DiemThanhPhans",
                column: "GiaoVienId");

            migrationBuilder.CreateIndex(
                name: "IX_DiemThanhPhans_HocKyId",
                table: "DiemThanhPhans",
                column: "HocKyId");

            migrationBuilder.CreateIndex(
                name: "IX_DiemThanhPhans_HocSinhId_MonHocId_HocKyId",
                table: "DiemThanhPhans",
                columns: new[] { "HocSinhId", "MonHocId", "HocKyId" });

            migrationBuilder.CreateIndex(
                name: "IX_DiemThanhPhans_HocSinhId_MonHocId_HocKyId_Loai_NgayNhap",
                table: "DiemThanhPhans",
                columns: new[] { "HocSinhId", "MonHocId", "HocKyId", "Loai", "NgayNhap" });

            migrationBuilder.CreateIndex(
                name: "IX_DiemThanhPhans_MonHocId",
                table: "DiemThanhPhans",
                column: "MonHocId");

            migrationBuilder.CreateIndex(
                name: "IX_GhiDanhs_HocKyId",
                table: "GhiDanhs",
                column: "HocKyId");

            migrationBuilder.CreateIndex(
                name: "IX_GhiDanhs_HocSinhId_HocKyId",
                table: "GhiDanhs",
                columns: new[] { "HocSinhId", "HocKyId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GhiDanhs_LopHocId",
                table: "GhiDanhs",
                column: "LopHocId");

            migrationBuilder.CreateIndex(
                name: "IX_HocKys_NamHoc_KyThu",
                table: "HocKys",
                columns: new[] { "NamHoc", "KyThu" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KhoiMons_MonHocId",
                table: "KhoiMons",
                column: "MonHocId");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocs_GVCNId",
                table: "LopHocs",
                column: "GVCNId");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocs_Ten",
                table: "LopHocs",
                column: "Ten",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MonHocs_Ten",
                table: "MonHocs",
                column: "Ten",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nguoi_Ma",
                table: "Nguoi",
                column: "Ma",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhanCongs_GiaoVienId_MonHocId_LopHocId_HocKyId",
                table: "PhanCongs",
                columns: new[] { "GiaoVienId", "MonHocId", "LopHocId", "HocKyId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhanCongs_HocKyId",
                table: "PhanCongs",
                column: "HocKyId");

            migrationBuilder.CreateIndex(
                name: "IX_PhanCongs_LopHocId",
                table: "PhanCongs",
                column: "LopHocId");

            migrationBuilder.CreateIndex(
                name: "IX_PhanCongs_MonHocId",
                table: "PhanCongs",
                column: "MonHocId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diems");

            migrationBuilder.DropTable(
                name: "DiemThanhPhans");

            migrationBuilder.DropTable(
                name: "GhiDanhs");

            migrationBuilder.DropTable(
                name: "KhoiMons");

            migrationBuilder.DropTable(
                name: "PhanCongs");

            migrationBuilder.DropTable(
                name: "HocKys");

            migrationBuilder.DropTable(
                name: "LopHocs");

            migrationBuilder.DropTable(
                name: "MonHocs");

            migrationBuilder.DropTable(
                name: "Nguoi");
        }
    }
}
