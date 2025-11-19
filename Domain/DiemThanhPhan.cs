using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DemoAppQLTH.Domain
{
    /// <summary>
    /// Điểm thành phần (có thể nhiều bản ghi mỗi loại cho một HS–Môn–Kỳ).
    /// Dùng kèm công thức tính để ra điểm tổng kết (nếu cần).
    /// </summary>
    [Index(nameof(HocSinhId), nameof(MonHocId), nameof(HocKyId))]
    public partial class DiemThanhPhan
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid HocSinhId { get; set; }
        public HocSinh? HocSinh { get; set; }

        public Guid MonHocId { get; set; }
        public MonHoc? MonHoc { get; set; }

        public Guid HocKyId { get; set; }
        public HocKy? HocKy { get; set; }

        public LoaiDiem Loai { get; set; }

        [Range(0, 10)]
        public double GiaTri { get; set; }

        public DateTime NgayNhap { get; set; } = DateTime.Now;

        /// <summary>(Tùy chọn) GV nhập điểm</summary>
        public Guid? GiaoVienId { get; set; }
        public GiaoVien? GiaoVien { get; set; }
    }
}