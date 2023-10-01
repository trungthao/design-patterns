namespace DesignPatterns.Services;

public class EmailNotifier : INotifier
{
    public string Send(string message)
    {
        return "Send Email: " + message;
    }
}