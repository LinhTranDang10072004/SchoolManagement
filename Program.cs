// Program.cs
using System;
using System.Windows.Forms;
using DemoAppQLTH.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using QuanLyTruongHocV1.UI.Forms;

namespace QuanLyTruongHocV1
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                using var ctx = new SchoolDbContextFactory().CreateDbContext(Array.Empty<string>());
                ctx.Database.Migrate();
                Seeder.Seed(ctx);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo DB: " + ex.Message);
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}
