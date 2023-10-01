namespace DesignPatterns.Services.Composite;

public class FakeFileData
{
    public static IFile GetFileData()
    {
        Folder folder = new Folder()
        {
            Children = new List<IFile>()
            {
                new File() { Size = 100 },
                new File() { Size = 200 },
                new Folder()
                {
                    Children = new List<IFile>()
                    {
                        new File() { Size = 150 }, new File() { Size = 250 }, new File() { Size = 300 }
                    }
                },
                new File() { Size = 450 },
                new Folder()
                {
                    Children = new List<IFile>()
                    {
                        new File() { Size = 50 }, new File() { Size = 50 }, new File() { Size = 350 }
                    }
                }
            }
        };

        return folder;
    }
}