namespace aoc.D07
{
  public class Shell
  {
    private string[] _lines;
    private Folder _rootFolder;
    private Folder _currentFolder;

    public Shell(string path)
    {
      _rootFolder = new Folder("/", null);
      _currentFolder = _rootFolder;
      _lines = File.ReadAllLines(path);
      Process();
    }

    public int PartI()
    {
      var list = TraverseTree();
      var candidates = list.FindAll(f => f.Size < 100000);

      int sum = 0;
      foreach (var item in candidates)
        sum += item.Size;

      return sum;
    }

    public int PartII()
    {
      int diskSPace = 70000000;
      int spaceNeeded = 30000000;
      int freeSpace = diskSPace - _rootFolder.Size;

      var list = TraverseTree();
      var candidates = list.FindAll(f => freeSpace + f.Size > spaceNeeded);
      candidates = candidates.OrderBy(f =>  f.Size).ToList();
      return candidates[0].Size;
    }

    private void Process()
    {
      for (int i = 0; i < _lines.Length; i++)
      {
        var fragment = _lines[i].Split(' ');

        if (fragment[0].Trim() == "$" && fragment[1].Trim() == "cd")
          ChangeFolder(fragment[2]);
        else
        {
          if (fragment[0].Trim() == "$" && fragment[1].Trim() == "ls")
          {
            int linesread= 0;
            while (true)
            {
              if (i + linesread + 1 == _lines.Length) //if last line reached, do not seek a $
                break;

              var line = _lines[i + linesread + 1].Split(' ');  

              if (line[0].Trim() == "$")
              {
                i += linesread;
                break;
              }
              else
              {
                //if dir, create if it does not exist already in the current folder's child folders
                if (line[0].Trim() == "dir")
                {
                  if (_currentFolder.Folders.Find(x => x.Name == line[1]) == null)                  
                    _currentFolder.AddChildFolder(new Folder(line[1], _currentFolder));
                }
                else
                {
                  //create file, if it does not exist already in the current folder's files
                  if (_currentFolder.Files.Find(x => x.Name == line[1]) == null)
                    _currentFolder.AddFile(new Filex(line[1], int.Parse(line[0]), _currentFolder));
                }

                linesread++;
              }
            }
          }
        }
      }
    }

    private void ChangeFolder(string name)
    {
      switch (name)
      {
        case "/":
          _currentFolder = _rootFolder;
          break;

        case "..":
          if (_currentFolder.Parent != null)
            _currentFolder = _currentFolder.Parent;        
          break;

        default:
          var temp = _currentFolder.Folders.Find(x => x.Name == name);
          if (temp != null)
            _currentFolder = temp;
          break;
      }
    }

    private List<Folder> TraverseTree()
    {
      var all = new List<Folder>();
      var folders = new Stack<Folder>(20);

      folders.Push(_rootFolder);
      all.Add(_rootFolder);

      while (folders.Count > 0)
      {
        var currentDir = folders.Pop();

        foreach (var f in currentDir.Folders)
        {
          folders.Push(f);
          all.Add(f);
        }
      }

      return all;
    }
  }
}
