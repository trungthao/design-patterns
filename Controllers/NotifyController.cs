using DesignPatterns.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotifyController : ControllerBase
    {
        private readonly INotificationServiceOld _notificationServiceOld;
        private readonly INotificationServiceNew _notificationServiceNew;
        
        public NotifyController(INotificationServiceOld notificationServiceOld, INotificationServiceNew notificationServiceNew)
        {
            _notificationServiceOld = notificationServiceOld;
            _notificationServiceNew = notificationServiceNew;
        }
        [HttpGet("old")]
        public IActionResult SendNotificationOld([FromQuery]string message, [FromQuery]NotifyType notifyType)
        {
            var newMessenger = _notificationServiceOld.Send(message, notifyType);
            return Ok(newMessenger);
        }
        
        [HttpGet("strategy")]
        public IActionResult SendNotificationWithStrategy([FromQuery]string message, [FromQuery]NotifyType notifyType)
        {
            INotifier notifier = null;
            var newMessenger = string.Empty;
            switch (notifyType)
            {
                case NotifyType.Email:
                    notifier = new EmailNotifier();
                    break;
                case NotifyType.SMS:
                    notifier = new SMSNotifier();
                    break;
                case NotifyType.Zalo:
                    notifier = new ZaloNotifier();
                    break;
            }

            if (notifier != null)
            {
                newMessenger = _notificationServiceNew.Send(notifier, message);
            }

            return Ok(newMessenger);
        }
        
        [HttpGet("factory-method")]
        public IActionResult SendNotificationWithFactoryMethod([FromQuery]string message, [FromQuery]NotifyType notifyType)
        {
            INotifier notifier = NotifierFactory.CreateNotifier(notifyType);
            var newMessenger = string.Empty;

            if (notifier != null)
            {
                newMessenger = _notificationServiceNew.Send(notifier, message);
            }

            return Ok(newMessenger);
        }
        
        [HttpGet("decorator")]
        public IActionResult SendNotificationWithDecorator([FromQuery]string message)
        {
            INotifier emailNotifier = NotifierFactory.CreateNotifier(NotifyType.Email);
            INotifier smsNotifier = NotifierFactory.CreateNotifier(NotifyType.SMS);
            INotifier zaloNotifier = NotifierFactory.CreateNotifier(NotifyType.Zalo);
            var notifierDecorator = new NotifierDecorator(null, emailNotifier)
                .Decorator(zaloNotifier)
                .Decorator(smsNotifier);
            
            var newMessenger = string.Empty;

            if (notifierDecorator != null)
            {
                newMessenger = _notificationServiceNew.Send(notifierDecorator, message);
            }

            return Ok(newMessenger);
        }
    }
}