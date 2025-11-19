using System;
using Microsoft.EntityFrameworkCore;

namespace DemoAppQLTH.Domain
{
    /// <summary>
    /// Phân công giảng dạy: GV dạy Môn cho Lớp trong Kỳ.
    /// Unique: (GiaoVienId, MonHocId, LopHocId, HocKyId).
    /// </summary>
    [Index(nameof(GiaoVienId), nameof(MonHocId), nameof(LopHocId), nameof(HocKyId), IsUnique = true)]
    public class PhanCong
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid GiaoVienId { get; set; }
        public GiaoVien? GiaoVien { get; set; }

        public Guid MonHocId { get; set; }
        public MonHoc? MonHoc { get; set; }

        public Guid LopHocId { get; set; }
        public LopHoc? LopHoc { get; set; }

        public Guid HocKyId { get; set; }
        public HocKy? HocKy { get; set; }
    }
}