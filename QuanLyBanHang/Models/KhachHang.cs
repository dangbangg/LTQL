using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    [Table("KhachHang")]
    public partial class KhachHang
    {

        public KhachHang()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        [StringLength(4)]
        public string MaKH { get; set; }

        [StringLength(30)]
        public string TenKH { get; set; }

        [StringLength(30)]
        public string DiaChi { get; set; }

        [StringLength(7)]
        public string DienThoai { get; set; }

        [StringLength(12)]
        public string Fax { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
        public string role { get; set; }
       
        [Required]
        public string password { get; set; }
        [NotMapped]
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("password")]
        public string confirm_password { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}