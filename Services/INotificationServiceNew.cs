namespace DesignPatterns.Services;

public interface INotificationServiceNew
{
    string Send(INotifier notifier, string message);
}