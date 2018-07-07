using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamTinHoc.Areas.Home.Models;
using TrungTamTinHoc.Areas.Home.Models.Schema;
using TTTH.Common;

namespace TrungTamTinHoc.Areas.Home.Controllers
{
    public class ContactController : Controller
    {
        /// <summary>
        /// Các điều hướng dành cho các trang liên quan đến Trang Contact
        /// Author       :   HaLTH - 03/07/2018 - create
        /// </summary>
        /// <remarks>
        /// Package      :   Home
        /// Copyright    :   Team Noname
        /// Version      :   1.0.0
        /// </remarks>
        public ActionResult Contact()
        {
            try
            {
                return View("Contact");
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { area = "error", error = e.Message });
            }

        }
        /// <summary>
        /// Lưu thông tin của người gửi tin nhắn liên hệ.
        /// Author       :   HaLTH - 03/07/2018 - create
        /// </summary>
        /// <param name="account">Thông tin nội dung liên hệ do người dùng nhập vào</param>
        /// <returns>Chỗi Json chứa kết quả của việc lưu dữ liệu</returns>
        /// <remarks>
        /// Method: POST
        /// RouterName: homeSaveContact
        /// </remarks>
        public ActionResult SaveContact(Contact contain)
        {
            ResponseInfo response = new ResponseInfo();
            if (ModelState.IsValid)
            {
                response = new ContactModel().SendMessenger(contain);
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        

    }
}