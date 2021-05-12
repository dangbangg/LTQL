namespace QuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KhachHang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CTHD",
                c => new
                    {
                        MaHD = c.String(nullable: false, maxLength: 5),
                        MaSP = c.String(nullable: false, maxLength: 4),
                        Soluong = c.Short(),
                        DongiaBan = c.Single(),
                        Giamgia = c.Single(),
                    })
                .PrimaryKey(t => new { t.MaHD, t.MaSP })
                .ForeignKey("dbo.HoaDon", t => t.MaHD, cascadeDelete: true)
                .ForeignKey("dbo.SanPham", t => t.MaSP, cascadeDelete: true)
                .Index(t => t.MaHD)
                .Index(t => t.MaSP);
            
            CreateTable(
                "dbo.HoaDon",
                c => new
                    {
                        MaHD = c.String(nullable: false, maxLength: 5),
                        MaKH = c.String(maxLength: 4),
                        MaNV = c.Int(),
                        NgayLapHD = c.DateTime(nullable: false),
                        NgayGiaoHang = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaHD)
                .ForeignKey("dbo.KhachHang", t => t.MaKH, cascadeDelete: true)
                .ForeignKey("dbo.NhanVien", t => t.MaNV, cascadeDelete: true)
                .Index(t => t.MaKH)
                .Index(t => t.MaNV);
            
            CreateTable(
                "dbo.KhachHang",
                c => new
                    {
                        MaKH = c.String(nullable: false, maxLength: 4),
                        TenKH = c.String(maxLength: 30),
                        DiaChi = c.String(maxLength: 30),
                        DienThoai = c.String(maxLength: 7),
                        Fax = c.String(maxLength: 12),
                        Email = c.String(nullable: false),
                        password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaKH);
            
            CreateTable(
                "dbo.NhanVien",
                c => new
                    {
                        MaNV = c.Int(nullable: false, identity: true),
                        HoNV = c.String(maxLength: 50),
                        Ten = c.String(maxLength: 50),
                        Diachi = c.String(maxLength: 50),
                        Dienthoai = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaNV);
            
            CreateTable(
                "dbo.SanPham",
                c => new
                    {
                        MaSP = c.String(nullable: false, maxLength: 4),
                        TenSP = c.String(maxLength: 20),
                        Donvitinh = c.String(maxLength: 8),
                        Dongia = c.Double(),
                        MaLoaiSP = c.Int(),
                        HinhSP = c.String(),
                    })
                .PrimaryKey(t => t.MaSP)
                .ForeignKey("dbo.LoaiSP", t => t.MaLoaiSP, cascadeDelete: true)
                .Index(t => t.MaLoaiSP);
            
            CreateTable(
                "dbo.LoaiSP",
                c => new
                    {
                        MaLoaiSP = c.Int(nullable: false),
                        TenLoaiSP = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.MaLoaiSP);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanPham", "MaLoaiSP", "dbo.LoaiSP");
            DropForeignKey("dbo.CTHD", "MaSP", "dbo.SanPham");
            DropForeignKey("dbo.HoaDon", "MaNV", "dbo.NhanVien");
            DropForeignKey("dbo.HoaDon", "MaKH", "dbo.KhachHang");
            DropForeignKey("dbo.CTHD", "MaHD", "dbo.HoaDon");
            DropIndex("dbo.SanPham", new[] { "MaLoaiSP" });
            DropIndex("dbo.HoaDon", new[] { "MaNV" });
            DropIndex("dbo.HoaDon", new[] { "MaKH" });
            DropIndex("dbo.CTHD", new[] { "MaSP" });
            DropIndex("dbo.CTHD", new[] { "MaHD" });
            DropTable("dbo.LoaiSP");
            DropTable("dbo.SanPham");
            DropTable("dbo.NhanVien");
            DropTable("dbo.KhachHang");
            DropTable("dbo.HoaDon");
            DropTable("dbo.CTHD");
        }
    }
}
