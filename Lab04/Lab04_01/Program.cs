using System;
using System.IO;

public class MyDirectory
{
    public string Path { get; private set; }

    public MyDirectory(string path)
    {
        Path = path;
    }

    public void Create()
    {
        Directory.CreateDirectory(Path);
    }

    public void Delete()
    {
        Directory.Delete(Path, true);
    }

    public override bool Equals(object obj)
    {
        return obj is MyDirectory directory &&
               Path == directory.Path;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Path);
    }

    public override string ToString()
    {
        return $"Directory Path: {Path}";
    }
}

public class MyFile
{
    public string Name { get; private set; }
    public MyDirectory Directory { get; private set; }

    public MyFile(string name, MyDirectory directory)
    {
        Name = name;
        Directory = directory;
    }

    public void Rename(string newName)
    {
        var oldPath = System.IO.Path.Combine(Directory.Path, Name);
        var newPath = System.IO.Path.Combine(Directory.Path, newName);
        System.IO.File.Move(oldPath, newPath);
        Name = newName;
    }

    public void Delete()
    {
        var path = System.IO.Path.Combine(Directory.Path, Name);
        System.IO.File.Delete(path);
    }

    public override bool Equals(object obj)
    {
        return obj is MyFile file &&
               Name == file.Name &&
               EqualityComparer<MyDirectory>.Default.Equals(Directory, file.Directory);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Directory);
    }

    public override string ToString()
    {
        return $"File: {Name}, Directory: {Directory}";
    }
}

public class TextFile : MyFile
{
    public TextFile(string name, MyDirectory directory) : base(name, directory) { }

    public void Create()
    {
        var path = System.IO.Path.Combine(Directory.Path, Name);
        using (StreamWriter sw = System.IO.File.CreateText(path))
        {
            sw.WriteLine("");
        }
    }

    public void AppendText(string text)
    {
        var path = System.IO.Path.Combine(Directory.Path, Name);
        using (StreamWriter sw = System.IO.File.AppendText(path))
        {
            sw.WriteLine(text);
        }
    }

    public void DisplayContents()
    {
        var path = System.IO.Path.Combine(Directory.Path, Name);
        using (StreamReader sr = System.IO.File.OpenText(path))
        {
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }
        }
    }
}

public class Program
{
    static void Main(string[] args)
    {
        MyDirectory dir = new MyDirectory("./mydir");
        dir.Create();

        TextFile file = new TextFile("mytextfile.txt", dir);
        file.Create();
        file.AppendText("Hello, World!");
        file.DisplayContents();
        file.Rename("newtextfile.txt");
        file.DisplayContents();

        dir.Delete();
    }
}