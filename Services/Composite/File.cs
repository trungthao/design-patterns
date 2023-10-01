namespace DesignPatterns.Services.Composite;

public class File : IFile
{
    public decimal Size { get; set; }
    
    public decimal GetTotalSize()
    {
        return Size;
    }
}