using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TrungTamTinHoc.Areas.Home.Models.Schema;
using TTTH.Common;
using TTTH.DataBase;
using TblDangKyTemp = TTTH.DataBase.Schema.DangKyTemp;
using TblKhoaHoc = TTTH.DataBase.Schema.KhoaHoc;

namespace TrungTamTinHoc.Areas.Home.Models
{
    /// <summary>
    /// Class chứa các phương thức liên quan đến việc đăng ký khóa học
    /// Author       :   AnTM - 24/06/2018 - create
    /// </summary>
    /// <remarks>
    /// Package      :   Home.Models
    /// Copyright    :   Team Noname
    /// Version      :   1.0.0
    /// </remarks>
    public class RegisterCourseModel
    {
        private DataContext context;
        public RegisterCourseModel()
        {
            context = new DataContext();
        }

        /// <summary>
        /// Lấy danh sách các khóa học được phép hiển thị từ DB theo ngôn ngữ.
        /// Author       :   AnTM - 24/06/2018 - create
        /// </summary>
        /// <returns>Danh sách khóa học có trong DB</returns>
        public List<KhoaHocHienThi> GetKhoaHocHienThi()
        {
            try
            {
                string lang = Common.GetLang();
                return context.KhoaHoc.Include("KhoaHocTrans").Where(x => !x.DelFlag).Select(x => new KhoaHocHienThi {
                    TenKhoaHoc = x.KhoaHocTrans.FirstOrDefault(y => y.Lang == lang).TenKhoaHoc,
                    IDKhoaHoc = x.Id
                }).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Lấy ID khóa học được selected trên view đăng ký khóa học từ DB.
        /// Author       :   AnTM - 24/06/2018 - create
        /// </summary>
        /// <returns>ID khóa học đc selected</returns>
        public int GetIdKhoaHocIsSelected(string beautyId)
        {
            try
            {
                return context.KhoaHoc.FirstOrDefault(x => x.BeautyId == beautyId).Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Tạo tài khoản cho người dùng dựa vào thông tin đã cung cấp, sau đó gửi mail kích hoạt tài khoản.
        /// Author       :   QuyPN - 20/05/2018 - create
        /// </summary>
        /// <param name="newAccount">Thông tin tạo tài khoản của người dùng</param>
        /// <returns>Thông tin về việc tạo tài khoản thành công hay thất bại</returns>
        public ResponseInfo DangKyKhoaHoc(DangKyKhoaHoc account)
        {
            DbContextTransaction transaction = context.Database.BeginTransaction();
            try
            {
                ResponseInfo result = new ResponseInfo();
                TblKhoaHoc khoaHoc= context.KhoaHoc.FirstOrDefault(x => x.Id == account.IDKhoaHoc);
                if (khoaHoc == null)
                {
                    result.Code = 202;
                    result.MsgNo = 42;
                    return result;
                }
                khoaHoc.DangKyTemps.Add(new TblDangKyTemp()
                {
                    HoTenBe = account.HoTenBe,
                    NgaySinh = account.NgaySinh,
                    HoTenBan = account.HoTenBan,
                    NgheNghiep = account.NgheNghiep,
                    DienThoai = account.SoDienThoai,
                    Email = account.Email,
                    DiaChi = account.DiaChi,
                    GhiChu = account.GhiChu,
                    TrangThai = 1
                });

                context.SaveChanges();
                transaction.Commit();
                return result;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw e;
            }
        }
    }
}