using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrungTamTinHoc.Areas.Home.Models.Schema
{
    /// <summary>
    /// Class thông tin của việc đăng ký khóa học sử dụng để lưu vào DB
    /// Author       :   AnTM - 24/06/2018 - create
    /// </summary>
    /// <remarks>
    /// Package      :   Home.Models
    /// Copyright    :   Team Noname
    /// Version      :   1.0.0
    /// </remarks>
    public class DangKyKhoaHoc
    {
        [Required(ErrorMessage = "1")]
        public int IDKhoaHoc { set; get; }

        [Required(ErrorMessage = "1")]
        [MaxLength(50, ErrorMessage = "2")]
        public string HoTenBe { set; get; }

        [Required(ErrorMessage = "1")]
        public DateTime NgaySinh { set; get; }

        [Required(ErrorMessage = "1")]
        [MaxLength(50, ErrorMessage = "2")]
        public string HoTenBan { set; get; }

        [Required(ErrorMessage = "1")]
        [MaxLength(100, ErrorMessage = "2")]
        public string NgheNghiep { set; get; }

        [Required(ErrorMessage = "1")]
        [MaxLength(15, ErrorMessage = "2")]
        public string SoDienThoai { set; get; }
        
        [Required(ErrorMessage = "1")]
        [MaxLength(255, ErrorMessage = "2")]
        [EmailAddress(ErrorMessage = "5")]
        public string Email { set; get; }

        [Required(ErrorMessage = "1")]
        [MaxLength(255, ErrorMessage = "2")]
        public string DiaChi { set; get; }

        [Required(ErrorMessage = "1")]
        [MaxLength(255, ErrorMessage = "2")]
        public string GhiChu { set; get; }

    }
    /// <summary>
    /// Class chứa các thuộc tính của 1 khóa học lấy từ DB cho việc hiển thị danh sách các khóa học trên combobox trang đăng ký khóa học
    /// Author       :   AnTM - 24/06/2018 - create
    /// </summary>
    /// <remarks>
    /// Package      :   Home.Models
    /// Copyright    :   Team Noname
    /// Version      :   1.0.0
    /// </remarks>
    public class KhoaHocHienThi
    {
        public int IDKhoaHoc { get; set; }
        public string TenKhoaHoc { set; get; }
        public bool isSelected { get; set; }
    }
}