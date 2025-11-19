using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DemoAppQLTH.Domain
{
    /// <summary>Học kỳ (NamHoc + KyThu). Khi DaKhoa = true thì khóa nhập/sửa điểm.</summary>
    [Index(nameof(NamHoc), nameof(KyThu), IsUnique = true)]
    public partial class HocKy
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>Ví dụ: "2025-2026"</summary>
        [Required, MaxLength(15)]
        public string NamHoc { get; set; } = "";

        /// <summary>1 hoặc 2</summary>
        [Range(1, 2)]
        public int KyThu { get; set; } = 1;

        /// <summary>Đã khóa điểm?</summary>
        public bool DaKhoa { get; set; } = false;

        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }

        // Navigation
        public ICollection<GhiDanh> GhiDanhs { get; set; } = new List<GhiDanh>();
        public ICollection<PhanCong> PhanCongs { get; set; } = new List<PhanCong>();
        public ICollection<Diem> Diems { get; set; } = new List<Diem>();
        public ICollection<DiemThanhPhan> DiemThanhPhans { get; set; } = new List<DiemThanhPhan>();

        /// <summary>Hiển thị tên đầy đủ</summary>
        [NotMapped] public string TenDayDu => $"{NamHoc}-K{KyThu}";
    }
}