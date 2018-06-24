using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamTinHoc.Areas.Home.Models;
using TrungTamTinHoc.Areas.Home.Models.Schema;
using TTTH.Common;
using TTTH.Validate;
using static TTTH.Common.Enums.ConstantsEnum;
using static TTTH.Common.Enums.MessageEnum;

namespace TrungTamTinHoc.Areas.Home.Controllers
{
    /// <summary>
    /// Class chứa các điều hướng liên quan đến đăng ký khóa học
    /// Author       :   AnTM - 24/06/2018 - create
    /// </summary>
    /// <remarks>
    /// Package      :   Home
    /// Copyright    :   Team Noname
    /// Version      :   1.0.0
    /// </remarks>
    public class RegisterCourseController : Controller
    {
        /// <summary>
        /// Điều hướng đến trang đăng ký khóa học.
        /// Author       :   AnTM - 24/06/2018 - create
        /// </summary>
        /// <param name="id">beauty ID của khóa học get từ url</param>
        /// <returns>Trang view đăng ký khóa học, nếu có lỗi sẽ rả về trang error</returns>
        /// <remarks>
        /// Method: GET
        /// RouterName: dang-ky-khoa-hoc
        /// </remarks>
        public ActionResult Index(string id)
        {
            try
            {
                RegisterCourseModel model = new RegisterCourseModel();
                if (id == null)
                {
                    ViewBag.IdKhoaHocSelected = -1;
                }
                else
                {
                    ViewBag.IdKhoaHocSelected = model.GetIdKhoaHocIsSelected(id);
                }
                ViewBag.ListKhoaHoc = model.GetKhoaHocHienThi();
                return View();
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { area = "error", error = e.Message });
            }

        }
        /// <summary>
        /// Đăng ký khóa học theo thông tin người dùng đưa lên.
        /// Author       :   AnTM - 24/06/2018 - create
        /// </summary>
        /// <param name="account">Thông tin đăng ký khóa học mà người dùng nhập vào</param>
        /// <returns>Chỗi Json chứa kết quả của việc đăng ký khóa học</returns>
        /// <remarks>
        /// Method: POST
        /// RouterName: homeRegisterCourse
        /// </remarks>
        public JsonResult DangKyKhoaHoc(DangKyKhoaHoc account)
        {
            ResponseInfo response = new ResponseInfo();
            try
            {
                if (ModelState.IsValid)
                {
                    response = new RegisterCourseModel().DangKyKhoaHoc(account);
                }
                else
                {
                    response.Code = (int)CodeResponse.NotValidate;
                    response.ListError = ModelState.GetModelErrors();
                }
            }
            catch (Exception e)
            {
                response.Code = (int)CodeResponse.ServerError;
                response.MsgNo = (int)MsgNO.ServerError;
                response.ThongTinBoSung1 = e.Message;
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }

    }
}