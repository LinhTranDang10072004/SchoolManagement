using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DemoAppQLTH.Domain
{
    /// <summary>Lớp học (thuộc Khối 10/11/12; có thể chỉ định GVCN)</summary>
    [Index(nameof(Ten), IsUnique = true)]
    public class LopHoc
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(32)]
        public string Ten { get; set; } = "";

        /// <summary>Khối lớp (10/11/12)</summary>
        [Range(10, 12)]
        public int Khoi { get; set; } = 10;

        /// <summary>Giáo viên chủ nhiệm (tùy chọn)</summary>
        public Guid? GVCNId { get; set; }
        public GiaoVien? GVCN { get; set; }

        // Navigation
        public ICollection<GhiDanh> GhiDanhs { get; set; } = new List<GhiDanh>();
        public ICollection<PhanCong> PhanCongs { get; set; } = new List<PhanCong>();
    }
}