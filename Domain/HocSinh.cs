using System.Collections.Generic;

namespace DemoAppQLTH.Domain
{
    /// <summary>Học sinh</summary>
    public class HocSinh : Nguoi
    {
        /// <summary>Ghi danh theo từng học kỳ (mỗi kỳ đúng 1 lớp)</summary>
        public ICollection<GhiDanh> GhiDanhs { get; set; } = new List<GhiDanh>();

        /// <summary>Điểm tổng kết (môn/kỳ)</summary>
        public ICollection<Diem> Diems { get; set; } = new List<Diem>();

        /// <summary>(Tùy chọn) Điểm thành phần chi tiết</summary>
        public ICollection<DiemThanhPhan> DiemThanhPhans { get; set; } = new List<DiemThanhPhan>();
    }
}