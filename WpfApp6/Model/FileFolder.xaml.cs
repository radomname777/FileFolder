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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp6.view;

namespace WpfApp6.Model
{
    /// <summary>
    /// Interaction logic for FileFolder.xaml
    /// </summary>
    
    public partial class FileFolder : UserControl
    {
        public string FolderNames { get; set; }  
        public FileFolder()
        {
            InitializeComponent();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
     
            Folderclick fc = new Folderclick();
            fc.path = FolderNames;
            fc.Click();
            fc.ShowDialog();
        }
    }
}
