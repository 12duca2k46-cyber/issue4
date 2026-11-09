using Microsoft.EntityFrameworkCore;
using MoneyCare.Models;

namespace MoneyCare.Data
{
    public class MoneyCareContext : DbContext
    {
        public MoneyCareContext(DbContextOptions<MoneyCareContext> options)
            : base(options)
        {
        }

        public DbSet<NguoiDung> NguoiDung { get; set; } = null!;
        public DbSet<DanhMuc> DanhMuc { get; set; } = null!;
        public DbSet<GiaoDich> GiaoDich { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // SQLQuery1.sql co UNIQUE (MaDanhMuc, UserId)
            modelBuilder.Entity<DanhMuc>()
                .HasAlternateKey(d => new { d.MaDanhMuc, d.UserId });

            // Mot nguoi dung co nhieu giao dich
            modelBuilder.Entity<GiaoDich>()
                .HasOne(g => g.NguoiDung)
                .WithMany()
                .HasForeignKey(g => g.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // Giao dich chi su dung danh muc cua dung UserId
            modelBuilder.Entity<GiaoDich>()
                .HasOne(g => g.DanhMuc)
                .WithMany()
                .HasForeignKey(g => new { g.MaDanhMuc, g.UserId })
                .HasPrincipalKey(d => new { d.MaDanhMuc, d.UserId })
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
