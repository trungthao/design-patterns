namespace DesignPatterns.Services;

public interface INotificationServiceOld
{
    string Send(string message, NotifyType notifyType);
}