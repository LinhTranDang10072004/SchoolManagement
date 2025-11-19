// File: Domain/Extensions/DiemThanhPhanExtensions.cs
using System;

namespace DemoAppQLTH.Domain
{
    /// <summary>Extension methods cho DiemThanhPhan.</summary>
    public static class DiemThanhPhanExtensions
    {
        /// <summary>Gán giá trị điểm (0..10) và làm tròn 2 chữ số.</summary>
        public static void GanGiaTri(this DiemThanhPhan dtp, double value)
        {
            if (value < 0.0 || value > 10.0)
                throw new ArgumentOutOfRangeException(nameof(value), "Điểm phải trong [0..10]");
            dtp.GiaTri = Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }
    }
}
