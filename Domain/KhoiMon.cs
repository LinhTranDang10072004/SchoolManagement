using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DemoAppQLTH.Domain
{
    /// <summary>
    /// Cấu hình môn “chuẩn” theo khối (10/11/12).
    /// Dùng để Admin gán bộ môn cho từng khối; lớp cùng khối sẽ chia sẻ bộ môn này.
    /// </summary>
    [PrimaryKey(nameof(Khoi), nameof(MonHocId))]
    public class KhoiMon
    {
        /// <summary>10 / 11 / 12</summary>
        [Range(10, 12)]
        public int Khoi { get; set; }

        public Guid MonHocId { get; set; }
        public MonHoc? MonHoc { get; set; }
    }
}