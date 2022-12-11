using System.Xml.Linq;

namespace aoc.D07
{
  public class Filex
  {
    private string _name;
    private int _size;
    private Folder _folder;

    public Filex(string name, int size, Folder folder)
    {
      _name = name;
      _size = size;
      _folder = folder;
    }

    public string Name
    {
      get => _name;
      set => _name = value;
    }

    public int Size
    {
      get => _size;
      set => _size = value;
    }

    public Folder Folder
    {
      get => _folder;
      set => _folder = value;
    }
  }
}
