using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    [Table("HoaDon")]
    public partial class HoaDon
    {
        public HoaDon()
        {
            CTHDs = new HashSet<CTHD>();
        }

        [Key]
        [StringLength(5)]
        public string MaHD { get; set; }

        [StringLength(4)]
        public string MaKH { get; set; }

        public int? MaNV { get; set; }

        public DateTime NgayLapHD { get; set; }

        public DateTime NgayGiaoHang { get; set; }
        public virtual ICollection<CTHD> CTHDs { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual NhanVien Nhanvien { get; set; }
    }
}