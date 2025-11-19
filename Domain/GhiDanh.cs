using System;
using Microsoft.EntityFrameworkCore;

namespace DemoAppQLTH.Domain
{
    /// <summary>
    /// Ghi danh: học sinh thuộc lớp nào trong một học kỳ.
    /// Unique: (HocSinhId, HocKyId) để mỗi kỳ HS chỉ ở đúng 1 lớp.
    /// </summary>
    [Index(nameof(HocSinhId), nameof(HocKyId), IsUnique = true)]
    public class GhiDanh
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid HocSinhId { get; set; }
        public HocSinh? HocSinh { get; set; }

        public Guid LopHocId { get; set; }
        public LopHoc? LopHoc { get; set; }

        public Guid HocKyId { get; set; }
        public HocKy? HocKy { get; set; }
    }
}