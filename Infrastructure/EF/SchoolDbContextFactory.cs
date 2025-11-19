// Infrastructure/EF/SchoolDbContextFactory.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DemoAppQLTH.Infrastructure.EF
{
    public class SchoolDbContextFactory : IDesignTimeDbContextFactory<SchoolDbContext>
    {
        public SchoolDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<SchoolDbContext>()
                .UseSqlServer(DbConfig.ConnectionString)
                .Options;
            return new SchoolDbContext(options);
        }
    }
}
