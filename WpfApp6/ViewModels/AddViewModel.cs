
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using WpfApp6;
using WpfApp6.Command;
using WpfApp6.Composite;
using WpfApp6.Model;
using WpfApp6.view;

namespace MVVM.ViewModels;


public class AddViewModel : ViewModelBase
{
    private MainWindow MW { get; set; }
    private Folderclick FC { get; set; }
    private Folder Folder { get; set; } = new Folder();
    public RelayCommand AddCommand { get; set; }
    public bool isok { get; set; }
    public AddViewModel(MainWindow obj)
    {
        MW = obj;
        AddCommand = new(Add, CanAdd);
    }
    public AddViewModel(Folderclick obj,string path)
    {
        FC = obj;
        FC.WP.Children.Clear();
        Folder Folder2 = new();
        Folder2.SelectedFolder(path);
        foreach (var item in Folder2.Folders)
            FC.WP.Children.Add(FIFO(item));

            foreach (var item in Directory.GetFiles(path, "*.*"))
                FC.WP.Children.Add(Files(item));


    }

    private void SelectFolder()
    {
        double num = Folder.selecetFolder();
        if (num>-1)
        {
            string value =  String.Format("{0:0.0}", num / 1024 / 1024);
            isok = true;
            MW.LIST.Children.Clear();
            MW.mylbl.Content = $"Filesize {value} MB";
            Addcontrol(Folder.Folders);
            FileControl(Folder.Path.SelectedPath);
        }
    }
    private string StringMethods(string str)
    {
        int count = str.Count(s => s == '\\');
        string  str_new = ""; int num = 0;
        foreach (var item in str)
        {
            if (item == '\\' && num < count) num++;  
            else if (num>= count) str_new += item;
        }
        return str_new;
    }
    private List<string> Lstr = new();
    private FileFolder FIFO(string name)
    {
        DirectoryInfo d = new DirectoryInfo(name);
        FileFolder FIFO = new FileFolder();
        FIFO.FolderNames = name;
        try
        {
            FileInfo[] Files = d.GetFiles("*.*");
            foreach (var item in Files) Lstr.Add(item.FullName);
            FIFO.Label1.Content = StringMethods(name);
            FIFO.Margin = new Thickness(10);
          
        }
        catch (Exception) {
            MW.blm = false;
        }
        return FIFO;

    }
    private Filex Files(string name)
    {
        Filex file = new();
        file.Label1.Content = StringMethods(name);
        file.Margin = new Thickness(10);
        return file;
    }
    private void FileControl(string FolderName)
    {
        if (Directory.GetFiles(FolderName, "*.*").Length != 0)
            foreach (var item in Directory.GetFiles(FolderName, "*.*"))
                MW.LIST.Children.Add(Files(item));
    }
    private void Addcontrol(string[] arr)
    {
        foreach (var item in arr)
        {
            FileFolder f = FIFO(item);
            if (!MW.blm)
            {
                MW.LIST.Children.Clear();
                MessageBox.Show("Error file");
                MainWindow main2 = new MainWindow();
                MW.Close();
                MW = main2;
                main2.ShowDialog();
                return;
            }
            MW.LIST.Children.Add(f);
        }
    }
    private void Add(object? parameter) =>SelectFolder();
    private bool CanAdd(object? parametr) => true;


}
