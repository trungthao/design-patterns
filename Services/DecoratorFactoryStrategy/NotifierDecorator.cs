namespace DesignPatterns.Services;

public class NotifierDecorator : INotifier
{
    private NotifierDecorator _core;
    private INotifier _notifier;

    public NotifierDecorator(NotifierDecorator core, INotifier notifier)
    {
        _core = core;
        _notifier = notifier;
    }
    
    public string Send(string message)
    {
        var result = _notifier.Send(message);

        if (_core != null)
        {
            result += Environment.NewLine + _core.Send(message);
        }

        return result;
    }

    public NotifierDecorator Decorator(INotifier notifier)
    {
        return new NotifierDecorator(this, notifier);
    }
}