using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    [Table("CTHD")]
    public class CTHD
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(5)]
        public string MaHD { get; set; }

        [Key]   
        [Column(Order = 1)]
        [StringLength(4)]
        public string MaSP { get; set; }

        public short? Soluong { get; set; }

        public float? DongiaBan { get; set; }

        public float? Giamgia { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}