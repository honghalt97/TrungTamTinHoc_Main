using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TTTH.DataBase.Schema
{
    [Table("DangKyLopHoc")]
    public partial class DangKyLopHoc : TableHaveIdInt
    {
        public int IdUser { get; set; }

        public int IdLopHoc { get; set; }

        [Required]
        [StringLength(50)]
        public string HoHocVien { set; get; }

        [Required]
        [StringLength(50)]
        public string TenHocVien { set; get; }

        [Required]
        public bool GioiTinhHocVien { set; get; }

        [Required]
        public DateTime NgaySinhHocVien { set; get; }

        [StringLength(100)]
        public string DiaChiHocVien { set; get; }

        [StringLength(5)]
        public string IdXaHocVien { set; get; }

        [Required]
        [StringLength(50)]
        public string HoGiamHo { set; get; }

        [Required]
        [StringLength(50)]
        public string TenGiamHo { set; get; }

        [Required]
        public bool GioiTinhGiamHo { set; get; }

        [Required]
        public DateTime NgaySinhGiamHo { set; get; }

        [StringLength(100)]
        public string DiaChiGiamHo { set; get; }

        [StringLength(5)]
        public string IdXaGiamHo { set; get; }

        [Required]
        [StringLength(15)]
        public string SoDienThoaiGiamHo { set; get; }

        [StringLength(255)]
        public string EmailGiamHo { set; get; }

        [StringLength(100)]
        public string GhiChu { set; get; }

        public DateTime ThoiGianDangKy { get; set; }

        public int TrangThaiDangKy { get; set; }

        public virtual LopHoc LopHoc { get; set; }

        public virtual TrangThai TrangThai { get; set; }

        public virtual User User { get; set; }

        public virtual Xa XaHocVien { set; get; }

        public virtual Xa XaGiamHo { set; get; }
    }
}
