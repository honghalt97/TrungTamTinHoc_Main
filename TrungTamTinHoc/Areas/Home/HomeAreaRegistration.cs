﻿using System.Web.Mvc;

namespace TrungTamTinHoc.Areas.Home
{
    public class HomeAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "home";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "homeCheckLogin",
                "home/login/check-login",
                new { controller = "Login", action = "CheckLogin", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "homeCheckSocialLogin",
                "home/login/check-social-login",
                new { controller = "Login", action = "LoginBySocialAccount", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "homeLogout",
                "home/logout",
                new { controller = "Login", action = "Logout", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "homeCreateAccount",
                "home/create-account",
                new { controller = "RegisterAccount", action = "CreateAccount", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "homeRegisterCourse",
                "home/register-course",
                new { controller = "RegisterCourse", action = "DangKyKhoaHoc", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "homeCheckExistAccount",
                "home/check-exist-account",
                new { controller = "RegisterAccount", action = "CheckExistAccount", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "homeSendEmailById",
                "home/resend-email",
                new { controller = "RegisterAccount", action = "SendEmailById", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "homeSendEmail",
                "home/send-email",
                new { controller = "RegisterAccount", action = "SendEmail", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "homeDefault",
                "home/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}