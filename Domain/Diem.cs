using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DemoAppQLTH.Domain
{
    /// <summary>
    /// Điểm tổng kết môn/kỳ của học sinh.
    /// Unique: (HocSinhId, MonHocId, HocKyId).
    /// </summary>
    [Index(nameof(HocSinhId), nameof(MonHocId), nameof(HocKyId), IsUnique = true)]
    public class Diem
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid HocSinhId { get; set; }
        public HocSinh? HocSinh { get; set; }

        public Guid MonHocId { get; set; }
        public MonHoc? MonHoc { get; set; }

        public Guid HocKyId { get; set; }
        public HocKy? HocKy { get; set; }

        /// <summary>0..10</summary>
        [Range(0, 10)]
        public double GiaTri { get; set; }
    }
}