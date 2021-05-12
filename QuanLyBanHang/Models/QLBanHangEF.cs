namespace QuanLyBanHang.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLBanHangEF : DbContext
    {
        public QLBanHangEF()
            : base("name=QLBanHangEF")
        {
        }
        public virtual DbSet<CTHD> CTHDs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiSP> LoaiSPs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.HoaDons)
                .WithOptional(e => e.KhachHang)
                .WillCascadeOnDelete();

            modelBuilder.Entity<LoaiSP>()
                .HasMany(e => e.SanPhams)
                .WithOptional(e => e.LoaiSP)
                .WillCascadeOnDelete();

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.HoaDons)
                .WithOptional(e => e.Nhanvien)
                .WillCascadeOnDelete();
        }
    }
}
