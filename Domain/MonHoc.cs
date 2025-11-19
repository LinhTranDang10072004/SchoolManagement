using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DemoAppQLTH.Domain
{
    /// <summary>Môn học (có thể gán trọng số khi tính GPA)</summary>
    [Index(nameof(Ten), IsUnique = true)]
    public class MonHoc
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(64)]
        public string Ten { get; set; } = "";

        /// <summary>Trọng số/GV quy đổi khi tính GPA (mặc định 1)</summary>
        [Range(1, 10)]
        public int HeSo { get; set; } = 1;

        // Navigation
        public ICollection<PhanCong> PhanCongs { get; set; } = new List<PhanCong>();
        public ICollection<Diem> Diems { get; set; } = new List<Diem>();
        public ICollection<DiemThanhPhan> DiemThanhPhans { get; set; } = new List<DiemThanhPhan>();
    }
}