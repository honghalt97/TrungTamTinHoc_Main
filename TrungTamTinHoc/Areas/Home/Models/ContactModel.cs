using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TrungTamTinHoc.Areas.Home.Models.Schema;
using TTTH.Common;
using TTTH.DataBase;
using TblContact = TTTH.DataBase.Schema.Contact;

namespace TrungTamTinHoc.Areas.Home.Models
{
    /// <summary>
    /// Class chứa các phương thức liên quan đến việc gửi tin nhắn liên hệ
    /// Author       :   HaLTH - 03/07/2018 - create
    /// </summary>
    /// <remarks>
    /// Package      :   Home.Models
    /// Copyright    :   Team Noname
    /// Version      :   1.0.0
    /// </remarks>
    public class ContactModel
    {
        private DataContext context;
        public ContactModel()
        {
            context = new DataContext();
        }
        /// <summary>
        /// Lưu thông tin của người gửi tin nhắn liên hệ.
        /// Author       :   HaLTH - 03/07/2018 - create
        /// </summary>
        /// <param name="newAccount">Nội dung liên hệ do người dùng cung cấp</param>
        /// <returns>Thông tin về việc gửi liên hệ thành công hay thất bại</returns>
        public ResponseInfo SendMessenger(Contact contain)
        {
            DbContextTransaction transaction = context.Database.BeginTransaction();
            try
            {
                ResponseInfo result = new ResponseInfo();
                //Lưu thông tin người dùng gửi liên hệ vào database
                TblContact contact = new TblContact
                {
                    HoTen = contain.HoTen,
                    Email = contain.Email,
                    SoDienThoai = contain.SoDienThoai,
                    NoiDung = contain.NoiDung,
                    IdTrangThai = 1
                };
                context.Contact.Add(contact);
                // Lưu vào CSDL
                context.SaveChanges();
                transaction.Commit();

                result.Code = 202;
                result.MsgNo = 41;

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