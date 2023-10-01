namespace DesignPatterns.Services;

public class NotifierFactory
{
    public static INotifier CreateNotifier(NotifyType notifyType)
    {
        INotifier notifier = null;
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

        return notifier;
    }
}