namespace DesignPatterns.Services;

public class SMSNotifier : INotifier
{
    public string Send(string message)
    {
        return "Send SMS: " + message;
    }
}