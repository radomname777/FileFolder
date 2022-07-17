using System.Windows.Forms;

using System;
using System.IO;
using System.Windows;


namespace WpfApp6.Composite;
interface SystemItem
{
    FolderBrowserDialog Path { get; set; }
    double Size { get; set; }
}


class Folder : SystemItem
{
    public FolderBrowserDialog Path { get; set; } = new();
    public Folder() { }
    public string[] Folders { get; set; }
    public double Size { get; set; } = -1;
    public void SelectedFolder(string path)
    {
        Folders = System.IO.Directory.GetDirectories(@$"{path}", "*", System.IO.SearchOption.TopDirectoryOnly);
    }
    public double selecetFolder()
    {

        if (Path.ShowDialog() == DialogResult.OK)
        {
            Folders = System.IO.Directory.GetDirectories(@$"{Path.SelectedPath}", @$"*", System.IO.SearchOption.TopDirectoryOnly);
            Size = CalculateFolderSize(Path.SelectedPath);
        }
        return Size;
    }
    protected static int CalculateFolderSize(string folder)
    {
        int folderSize = 0;
        if (!Directory.Exists(folder))
            return 0;
        else
        {
            try
            {
                foreach (string file in Directory.GetFiles(folder))
                {
                        FileInfo finfo = new FileInfo(file);
                        folderSize += Convert.ToInt32(finfo.Length);
                }

                foreach (string dir in Directory.GetDirectories(folder))
                    folderSize += CalculateFolderSize(dir);
            }
            catch{}
        }
        return folderSize;
    }
}


