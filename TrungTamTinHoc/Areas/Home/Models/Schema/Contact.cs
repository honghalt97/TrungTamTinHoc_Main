using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrungTamTinHoc.Areas.Home.Models.Schema
{
    /// <summary>
    /// Class thông tin của việcgửi tin nhắn trong phần liên lạc
    /// Author       :    HaLTH - 03/07/2018 - create
    /// </summary>
    /// <remarks>
    /// Package      :   Home.Models
    /// Copyright    :   Team Noname
    /// Version      :   1.0.0
    /// </remarks>
    public class Contact
    {
        [Required(ErrorMessage = "1")]
        [MaxLength(50, ErrorMessage = "2")]
        public string HoTen { set; get; }

        [Required(ErrorMessage = "1")]
        [MaxLength(255, ErrorMessage = "2")]
        [EmailAddress(ErrorMessage = "5")]
        public string Email { set; get; }

        [MaxLength(15, ErrorMessage = "2")]
        public string SoDienThoai { get; set; }

        [Required(ErrorMessage = "1")]
        public string NoiDung { set; get; }

        public int IdTrangThai { get; set; }
    }
}