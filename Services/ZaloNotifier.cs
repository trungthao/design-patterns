namespace DesignPatterns.Services;

public class ZaloNotifier : INotifier
{
    public string Send(string message)
    {
        return "Send Zalo: " + message;
    }
}