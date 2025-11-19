using System.Collections.Generic;

namespace DemoAppQLTH.Domain
{
    /// <summary>Giáo viên</summary>
    public class GiaoVien : Nguoi
    {
        /// <summary>Các phân công giảng dạy</summary>
        public ICollection<PhanCong> PhanCongs { get; set; } = new List<PhanCong>();

        /// <summary>Các lớp làm GVCN (nếu có)</summary>
        public ICollection<LopHoc> LopChuNhiems { get; set; } = new List<LopHoc>();
    }
}