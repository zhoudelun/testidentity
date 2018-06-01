using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using WebApplication1_identity.Services;

namespace WebApplication1_identity.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "确认你的Email",
                $"确认你的账号，<a href='{HtmlEncoder.Default.Encode(link)}'> 点击这里</a>.");
        }

        public static Task SendResetPasswordAsync(this IEmailSender emailSender, string email, string callbackUrl)
        {
            return emailSender.SendEmailAsync(email, "重置密码",
                $"重置你的密码， <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>点击这里</a>.");
        }
    }
}
