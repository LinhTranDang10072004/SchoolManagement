// File: Infrastructure/EF/SchoolDbContext.cs
using System.Linq;
using DemoAppQLTH.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoAppQLTH.Infrastructure.EF
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

        // ===== DbSet =====
        public DbSet<Nguoi> Nguoi => Set<Nguoi>();
        public DbSet<Admin> Admins => Set<Admin>();
        public DbSet<GiaoVien> GiaoViens => Set<GiaoVien>();
        public DbSet<HocSinh> HocSinhs => Set<HocSinh>();

        public DbSet<MonHoc> MonHocs => Set<MonHoc>();
        public DbSet<LopHoc> LopHocs => Set<LopHoc>();
        public DbSet<HocKy> HocKys => Set<HocKy>();

        public DbSet<GhiDanh> GhiDanhs => Set<GhiDanh>();
        public DbSet<PhanCong> PhanCongs => Set<PhanCong>();
        public DbSet<Diem> Diems => Set<Diem>();
        public DbSet<DiemThanhPhan> DiemThanhPhans => Set<DiemThanhPhan>();

        // NEW: môn chuẩn theo khối (10/11/12)
        public DbSet<KhoiMon> KhoiMons => Set<KhoiMon>();

        protected override void OnModelCreating(ModelBuilder model)
        {
            // ===== Inheritance TPH cho Nguoi =====
            model.Entity<Nguoi>()
                .HasDiscriminator<string>("Loai")
                .HasValue<Admin>("Admin")
                .HasValue<GiaoVien>("GiaoVien")
                .HasValue<HocSinh>("HocSinh");

            // ===== Keys & Unique Indexes =====
            model.Entity<Nguoi>().HasKey(x => x.Id);
            model.Entity<Nguoi>().HasIndex(x => x.Ma).IsUnique();

            model.Entity<MonHoc>().HasKey(x => x.Id);
            model.Entity<MonHoc>().HasIndex(x => x.Ten).IsUnique();

            model.Entity<LopHoc>().HasKey(x => x.Id);
            model.Entity<LopHoc>().HasIndex(x => x.Ten).IsUnique();

            model.Entity<HocKy>().HasKey(x => x.Id);
            model.Entity<HocKy>().HasIndex(x => new { x.NamHoc, x.KyThu }).IsUnique();

            model.Entity<GhiDanh>().HasKey(x => x.Id);
            model.Entity<GhiDanh>().HasIndex(x => new { x.HocSinhId, x.HocKyId }).IsUnique();

            model.Entity<PhanCong>().HasKey(x => x.Id);
            model.Entity<PhanCong>().HasIndex(x => new { x.GiaoVienId, x.MonHocId, x.LopHocId, x.HocKyId }).IsUnique();

            model.Entity<Diem>().HasKey(x => x.Id);
            model.Entity<Diem>().HasIndex(x => new { x.HocSinhId, x.MonHocId, x.HocKyId }).IsUnique();

            model.Entity<DiemThanhPhan>().HasKey(x => x.Id);
            model.Entity<DiemThanhPhan>().HasIndex(x => new { x.HocSinhId, x.MonHocId, x.HocKyId, x.Loai, x.NgayNhap });

            // NEW: KhoiMon (composite key)
            model.Entity<KhoiMon>().HasKey(x => new { x.Khoi, x.MonHocId });

            // ===== Relationships =====
            model.Entity<LopHoc>()
                 .HasOne(l => l.GVCN)
                 .WithMany(gv => gv.LopChuNhiems)
                 .HasForeignKey(l => l.GVCNId)
                 .OnDelete(DeleteBehavior.Restrict);

            model.Entity<GhiDanh>()
                 .HasOne(g => g.HocSinh)
                 .WithMany(hs => hs.GhiDanhs)
                 .HasForeignKey(g => g.HocSinhId)
                 .OnDelete(DeleteBehavior.Restrict);

            model.Entity<GhiDanh>()
                 .HasOne(g => g.LopHoc)
                 .WithMany(l => l.GhiDanhs)
                 .HasForeignKey(g => g.LopHocId)
                 .OnDelete(DeleteBehavior.Restrict);

            model.Entity<GhiDanh>()
                 .HasOne(g => g.HocKy)
                 .WithMany(k => k.GhiDanhs)
                 .HasForeignKey(g => g.HocKyId)
                 .OnDelete(DeleteBehavior.Restrict);

            model.Entity<PhanCong>()
                 .HasOne(p => p.GiaoVien)
                 .WithMany(gv => gv.PhanCongs)
                 .HasForeignKey(p => p.GiaoVienId)
                 .OnDelete(DeleteBehavior.Restrict);

            model.Entity<PhanCong>()
                 .HasOne(p => p.MonHoc)
                 .WithMany(m => m.PhanCongs)
                 .HasForeignKey(p => p.MonHocId)
                 .OnDelete(DeleteBehavior.Restrict);

            model.Entity<PhanCong>()
                 .HasOne(p => p.LopHoc)
                 .WithMany(l => l.PhanCongs)
                 .HasForeignKey(p => p.LopHocId)
                 .OnDelete(DeleteBehavior.Restrict);

            model.Entity<PhanCong>()
                 .HasOne(p => p.HocKy)
                 .WithMany(k => k.PhanCongs)
                 .HasForeignKey(p => p.HocKyId)
                 .OnDelete(DeleteBehavior.Restrict);

            model.Entity<Diem>()
                 .HasOne(d => d.HocSinh)
                 .WithMany(hs => hs.Diems)
                 .HasForeignKey(d => d.HocSinhId)
                 .OnDelete(DeleteBehavior.Restrict);

            model.Entity<Diem>()
                 .HasOne(d => d.MonHoc)
                 .WithMany(m => m.Diems)
                 .HasForeignKey(d => d.MonHocId)
                 .OnDelete(DeleteBehavior.Restrict);

            model.Entity<Diem>()
                 .HasOne(d => d.HocKy)
                 .WithMany(k => k.Diems)
                 .HasForeignKey(d => d.HocKyId)
                 .OnDelete(DeleteBehavior.Restrict);

            model.Entity<DiemThanhPhan>()
                 .HasOne(dp => dp.HocSinh)
                 .WithMany(hs => hs.DiemThanhPhans)
                 .HasForeignKey(dp => dp.HocSinhId)
                 .OnDelete(DeleteBehavior.Restrict);

            model.Entity<DiemThanhPhan>()
                 .HasOne(dp => dp.MonHoc)
                 .WithMany(m => m.DiemThanhPhans)
                 .HasForeignKey(dp => dp.MonHocId)
                 .OnDelete(DeleteBehavior.Restrict);

            model.Entity<DiemThanhPhan>()
                 .HasOne(dp => dp.HocKy)
                 .WithMany(k => k.DiemThanhPhans)
                 .HasForeignKey(dp => dp.HocKyId)
                 .OnDelete(DeleteBehavior.Restrict);

            // NEW: KhoiMon → MonHoc (Restrict)
            model.Entity<KhoiMon>()
                 .HasOne(km => km.MonHoc)
                 .WithMany()
                 .HasForeignKey(km => km.MonHocId)
                 .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(model);

            // Force Restrict cho MỌI FK (phòng quên chỗ nào)
            foreach (var fk in model.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                fk.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
