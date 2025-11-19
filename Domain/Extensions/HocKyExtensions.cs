// File: Domain/Extensions/HocKyExtensions.cs
using System;

namespace DemoAppQLTH.Domain
{
    /// <summary>Extension methods cho HocKy để thao tác an toàn mà không sửa class gốc.</summary>
    public static class HocKyExtensions
    {
        /// <summary>Khoá nhập điểm cho học kỳ.</summary>
        public static void KhoaNhapDiem(this HocKy hk)
        {
            hk.DaKhoa = true;
        }

        /// <summary>Mở khoá nhập điểm cho học kỳ.</summary>
        public static void MoKhoaNhapDiem(this HocKy hk)
        {
            hk.DaKhoa = false;
        }
    }
}
