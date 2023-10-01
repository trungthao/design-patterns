namespace DesignPatterns.Services.Composite;

public class Folder : IFile
{
    public List<IFile>? Children { get; set; }
    public decimal GetTotalSize()
    {
        decimal result = 0;
        if (Children != null && Children.Count > 0)
        {
            result = Children.Sum(x => x.GetTotalSize());
        }
        return result;
    }
}