/*
 * Các xử lý cho trang đăng ký khóa học
 * Author       :   AnTM - 24/06/2018 - create
 * Package      :   public/home
 * Copyright    :   Team Noname
 * Version      :   1.0.0
 */
$(document).ready(function () {
    InitRegister();
    InitEventRegister();
});
/*
 * Khởi tạo các giá trị ban đầu cho trang
 * Author       :   AnTM - 24/06/2018 - create
 * Param        :   
 * Output       :   
 */
function InitRegister() {
    try {
        $('[tabindex="1"]').first().focus();
    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Init Register:</b> ' + e.message, 4);
    }
}
/*
 * Khởi tạo các sự kiện của cho trang
 * Author       :   AnTM - 24/06/2018 - create
 * Param        :   
 * Output       :   
 */
function InitEventRegister() {
    try {
        $('#btn-register-course').on('click', function () {
            DangKyKhoaHoc();
        });
    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Init Event Register:</b> ' + e.message, 4);
    }
}
/*
 * Tiến hành gửi thông tin lên server để đăng ký tài khoản
 * Author       :   AnTM - 24/06/2018 - create
 * Param        :   
 * Output       :   
 */
function DangKyKhoaHoc() {
    try {
        if (!validate('#form-register-course')) {
            $.ajax({
                type: $('#form-register-course').attr('method'),
                url: $('#form-register-course').attr('action'),
                dataType: 'json',
                data: {
                    IDKhoaHoc: $('#KhoaHoc').val(),
                    HoTenBe: $('#HoTenBe').val(),
                    NgaySinh: $('#NgaySinh').val(),
                    HoTenBan: $('#HoTenBan').val(),
                    NgheNghiep: $('#NgheNghiep').val(),
                    SoDienThoai: $('#SoDienThoai').val(),
                    Email: ($('#Email').val()),
                    DiaChi: ($('#DiaChi').val()),
                    GhiChu: $('#GhiChu').val()
                },
                success: registerCourseSuccess
            });
        }
    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>DangKyKhoaHoc</b> ' + e.message, 4);
    }
}

/*
 * Xử lý sau khi đăng ký khoa hoc
 * Author       :   AnTM - 24/06/2018 - create
 * Param        :   res - đối tượng response trả về từ server
 * Output       :  
 */
function registerCourseSuccess(res) {
    try {
        if (res.Code == 200) {
            jMessage(41, function (r) {
                if (r) {
                    window.location = '/';
                }
            });
        } else {
            jMessage(res.MsgNo, function (ok) { });
        }
    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Create Account Response:</b> ' + e.message, 4);
        return true;
    }
}