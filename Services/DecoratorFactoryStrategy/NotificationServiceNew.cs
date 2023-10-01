namespace DesignPatterns.Services;

public class NotificationServiceNew : INotificationServiceNew
{
    public string Send(INotifier notifier, string message)
    { 
        return notifier.Send(message);
    }
}