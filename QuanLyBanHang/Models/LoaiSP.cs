using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    [Table("LoaiSP")]
    public  class LoaiSP
    {
        public LoaiSP()
        {
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaLoaiSP { get; set; }

        [StringLength(255)]
        public string TenLoaiSP { get; set; }
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}