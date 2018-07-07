/*
 * Các xử lý cho phần Đăng ký theo dõi qua email
 * Author       :   HaLTH - 03/07/2018 - create
 * Package      :   public/home
 * Copyright    :   Team Noname
 * Version      :   1.0.0
 */
var errorEmail = false;
$(document).ready(function () {
    InitSubscribe();
    InitEventSubscribe();
});
/*
 * Khởi tạo các giá trị ban đầu cho trang
 * Author       :   HaLTH - 03/07/2018 - create
 * Param        :   
 * Output       :   
 */
function InitSubscribe() {
    try {
        $('[tabindex="1"]').first().focus();
    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Init Subscribe:</b> ' + e.message, 4);
    }
}
/*
 * Khởi tạo các sự kiện của cho trang
 * Author       :   HaLTH - 03/07/2018 - create
 * Param        :   
 * Output       :   
 */
function InitEventSubscribe() {
    try {
        $('#btn-subscribe').on('click', function () {
            SubmitSubscribe();
        });
    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Init Event Subscribe:</b> ' + e.message, 4);
    }
}
/*
 * Thực hiện kiểm tra thông tin email do người dung cung cấp
 * Author       :   HaLTH - 03/07/2018 - create
 * Param        :   
 * Output       :   
 */
function SubmitSubscribe() {
    try {
        var error1 = validate('#form-subscribe');
        if (!error1 && !errorEmail) {
            $.ajax({
                type: $('#form-subscribe').attr('method'),
                url: $('#form-subscribe').attr('action'),
                dataType: 'json',
                data: {
                    Email: $('#Email').val()
                },
                success: SubscribeEmailResponse
            });
        }
        else {
            var lang = getLang();
            if (errorEmail) {
                $('#Email').errorStyle(_text[lang][MsgNo.EmailDaDangKy]);
            }
            $('.item-error').first().focus();
        }
    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Submit Subscribe:</b> ' + e.message, 4);
    }
}
/*
 * Kiểm tra tên đăng nhập hoặc email đã tồn tại trong hệ thống hay chưa
 * Author       :   HaLTH - 03/07/2018 - create
 * Param        :   input - text box nhập email
 * Output       :   true nếu có lỗi - false nếu không có lỗi
 */
function CheckExistEmail(string) {
    try {
        if ($(input).val() == '') {
            return;
        }
        var lang = getLang();
        $.ajax({
            type: 'GET',
            success: function (res) {
                if (res == 'True') {
                    $('#Email').errorStyle(_text[lang][MsgNo.EmailDaDangKy]);
                    errorEmail = true;
                }
                else {
                    errorEmail = false;
                }
            },
            global: false
        });
    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Check Exist Email:</b> ' + e.message, 4);
    }
}
/*
 * Xử lý sau khi đăng ký theo dõi
 * Author       :   HaLTH - 03/07/2018 - create
 * Param        :   res - đối tượng response trả về từ server
 * Output       :  
 */
function SubscribeEmailResponse(res) {
    try {
        if (res.Code == 200) {
            callLoading();
            jMessage(res.MsgNo, function (ok) {
            }, '<b>Success:</b> ');
        } else if (res.Code == 201) {
            fillError(res.ListError);
            $('.item-error').first().focus();
        } else {
            jMessage(res.MsgNo, function (ok) { });
        }
    }
    catch (e) {
        jMessage(0, function (ok) {
        }, '<b>Subscribe Email Response:</b> ' + e.message, 4);
        return true;
    }
}