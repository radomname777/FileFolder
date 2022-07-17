using MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp6.view
{
    /// <summary>
    /// Interaction logic for Folderclick.xaml
    /// </summary>
    public partial class Folderclick : Window
    {
        public AddViewModel add { get; set; }
        public string path { get; set; } = "";
        public Folderclick(){InitializeComponent();}
        public void Click()
        {
            add = new AddViewModel(this, path);
            DataContext = add;
        }
    }
}
