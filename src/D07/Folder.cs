namespace aoc.D07
{
  public class Folder
  {
    private string _name;
    private int _size;
    private Folder? _parent;
    readonly List<Folder> _folders;
    readonly List<Filex> _files;

    public Folder(string name, Folder? parent)
    {
      _name = name;
      _parent = parent;
      _folders = new List<Folder>();
      _files = new List<Filex>();
    }

    public string Name
    {
      get => _name;
      set => _name = value;
    }

    public int Size
    {
      get => ComputeSize();
    }

    public Folder? Parent
    {
      get => _parent;
      set => _parent = value;
    }

    public List<Folder> Folders
    {
      get => _folders;
    }

    public List<Filex> Files
    {
      get => _files;
    }

    public void AddChildFolder(Folder folder)
    {
      _folders.Add(folder);
    }

    public void AddFile(Filex file)
    {
      _files.Add(file);
    }

    private int ComputeSize()
    {
      int fileSum = 0, dirSum = 0;
      foreach (var file in _files)      
        fileSum += file.Size;      

      foreach (var folder in _folders)
        dirSum += folder.Size;

      return fileSum + dirSum;
    }
  }
}
