// Infrastructure/EF/DbConfig.cs
namespace DemoAppQLTH.Infrastructure.EF
{
    public static class DbConfig
    {
        // Dùng LocalDB, tạo DB mới để không đụng file cũ .mdf
        public static string ConnectionString =>
            @"Server=(localdb)\MSSQLLocalDB;
              Database=QuanLyTruongHoc2025;
              Trusted_Connection=True;
              MultipleActiveResultSets=true;
              TrustServerCertificate=true";
    }
}
