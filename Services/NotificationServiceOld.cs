using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Services
{

    public enum NotifyType
    {
        Email,
        SMS,
        Zalo
    }

    public class NotificationServiceOld : INotificationServiceOld
    {
        /*
         * Hàm này đang gặp 2 vấn đề
         * 1. Nếu bài toàn mở rộng, cho phép noti thêm các hình thức khác thì ta phải sửa hàm này -> vi phạm O trong SOLID
         * 2. Hàm này đang làm nhiều nhiệm vụ: gửi email, gửi sms, gửi zalo,...
         */
        public string Send(string message, NotifyType notifyType)
        {
            switch (notifyType)
            {
                case NotifyType.Email:
                    return "Send Email: " + message;
                case NotifyType.SMS:
                    return "Send SMS: " + message;
                case NotifyType.Zalo:
                    return "Send Zalo: " + message;
            }

            return string.Empty;
        }
    }
}