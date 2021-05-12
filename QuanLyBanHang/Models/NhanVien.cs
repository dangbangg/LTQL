using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    [Table("NhanVien")]
    public partial class NhanVien
    {
        public NhanVien()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        public int MaNV { get; set; }

        [StringLength(50)]
        public string HoNV { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        [StringLength(50)]
        public string Diachi { get; set; }

        [StringLength(50)]
        public string Dienthoai { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}